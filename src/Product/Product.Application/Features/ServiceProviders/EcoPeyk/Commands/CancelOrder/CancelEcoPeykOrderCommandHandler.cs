using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.EcoPeyk;
using Product.Application.Features.ServiceProviders.EcoPeyk.Queries.GetToken;
using System.Text;

namespace Product.Application.Features.ServiceProviders.EcoPeyk.Commands.CancelOrder
{
    public class CancelEcoPeykOrderCommandHandler : IRequestHandler<CancelEcoPeykOrderCommand, BaseResponse<EcoPeykCancelOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;
        private readonly IMediator _mediator;

        public CancelEcoPeykOrderCommandHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().EcoPeyk;
            _mediator = mediator;
        }

        public async Task<BaseResponse<EcoPeykCancelOrderResponse>> Handle(CancelEcoPeykOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string token = await _mediator.Send(new GetEcoPeykTokenQuery());
                HttpResponseMessage response = await SetHttpRequest(token, request);
                var res = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var errorResModel = JsonConvert.DeserializeObject<EcoPeykErrorResponse>(res);
                    return new(false, errorResModel!.Title);
                }

                var resModel = JsonConvert.DeserializeObject<EcoPeykCancelOrderResponse>(res);
                return new(true, "success");
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service EcoPeyk " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(string token, CancelEcoPeykOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl, token);

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}Order/CancelOrder");
            var response = await client.PostAsync(pUrl, content);
            return response;
        }
    }
}
