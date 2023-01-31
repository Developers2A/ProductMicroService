using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.CourierServices.EcoPeyk;
using Postex.Product.Application.Features.ServiceProviders.EcoPeyk.Queries.GetToken;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.Product.Application.Features.ServiceProviders.EcoPeyk.Queries.GetPrice
{
    public class GetEcoPeykPriceQueryHandler : IRequestHandler<GetEcoPeykPriceQuery, BaseResponse<List<EcoPeykGetPriceResponse>>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;
        private readonly IMediator _mediator;

        public GetEcoPeykPriceQueryHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().EcoPeyk;
            _mediator = mediator;
        }

        public async Task<BaseResponse<List<EcoPeykGetPriceResponse>>> Handle(GetEcoPeykPriceQuery request, CancellationToken cancellationToken)
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

                var resModel = JsonConvert.DeserializeObject<List<EcoPeykGetPriceResponse>>(res);
                if (resModel != null && resModel.Any())
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

        private async Task<HttpResponseMessage> SetHttpRequest(string token, GetEcoPeykPriceQuery request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl, token);
            var pUrl = new Uri($"{_gateway.BaseUrl}Parcel/Price");
            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync(pUrl, content);
            return response;
        }
    }
}
