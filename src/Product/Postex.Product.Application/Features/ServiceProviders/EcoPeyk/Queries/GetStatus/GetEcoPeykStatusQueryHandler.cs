using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.EcoPeyk;
using Postex.Product.Application.Features.ServiceProviders.EcoPeyk.Queries.GetToken;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.Product.Application.Features.ServiceProviders.EcoPeyk.Queries.GetStatus
{
    public class GetEcoPeykStatusQueryHandler : IRequestHandler<GetEcoPeykStatusQuery, BaseResponse<EcoPeykOrderStatusResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;
        private readonly IMediator _mediator;

        public GetEcoPeykStatusQueryHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().EcoPeyk;
            _mediator = mediator;
        }

        public async Task<BaseResponse<EcoPeykOrderStatusResponse>> Handle(GetEcoPeykStatusQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string token = await _mediator.Send(new GetEcoPeykTokenQuery());
                HttpResponseMessage response = await SetHttpRequest(token, request);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();

                var resModel = JsonConvert.DeserializeObject<EcoPeykOrderStatusResponse>(res);
                if (resModel!.StatusCode != 0)
                {
                    return new(true, "success", resModel);
                }

                return new(false, "fail");
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service EcoPeyk " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(string token, GetEcoPeykStatusQuery request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl, token);
            var serializedModel = JsonConvert.SerializeObject(request.Code);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}Order/OrderStatus");
            var response = await client.PostAsync(pUrl, content);
            return response;
        }
    }
}
