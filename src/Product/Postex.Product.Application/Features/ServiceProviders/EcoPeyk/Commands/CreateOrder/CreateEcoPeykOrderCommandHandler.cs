using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.EcoPeyk;
using Postex.Product.Application.Features.ServiceProviders.EcoPeyk.Queries.GetToken;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.Product.Application.Features.ServiceProviders.EcoPeyk.Commands.CreateOrder
{
    public class CreateEcoPeykOrderCommandHandler : IRequestHandler<CreateEcoPeykOrderCommand, BaseResponse<EcoPeykCreateOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;
        private readonly IMediator _mediator;

        public CreateEcoPeykOrderCommandHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().EcoPeyk;
            _mediator = mediator;
        }

        public async Task<BaseResponse<EcoPeykCreateOrderResponse>> Handle(CreateEcoPeykOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string token = await _mediator.Send(new GetEcoPeykTokenQuery());
                HttpResponseMessage response = await SetHttpRequest(token, request);
                var res = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    //var resModel = JsonConvert.DeserializeObject<EcoPeykCreateOrderErrorResponse>(res);
                    //return new(false, resModel.errors.ToString()!);
                    return new(false, response.Content.ReadAsStringAsync().Result);
                }

                var resModel = JsonConvert.DeserializeObject<EcoPeykCreateOrderResponse>(res);
                if (resModel!.RequestId > 0)
                {
                    return new(true, "success", resModel);
                }

                return new(false, "fail");
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Eco Peyk " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(string token, CreateEcoPeykOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl, token);

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}Order/InsertOrder");
            var response = await client.PostAsync(pUrl, content);
            return response;
        }
    }
}
