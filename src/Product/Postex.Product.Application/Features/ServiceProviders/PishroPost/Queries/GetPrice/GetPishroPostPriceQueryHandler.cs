using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.CourierServices.Chapar;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;

namespace Postex.Product.Application.Features.ServiceProviders.PishroPost.Queries.GetPrice
{
    public class GetPishroPostPriceQueryHandler : IRequestHandler<GetPishroPostPriceQuery, BaseResponse<ChaparGetPriceResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetPishroPostPriceQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Chapar;
        }

        public async Task<BaseResponse<ChaparGetPriceResponse>> Handle(GetPishroPostPriceQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<ChaparGetPriceResponse> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);
                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<ChaparGetPriceResponse>(res);
                if (resModel!.Result)
                {
                    return new(true, "success", resModel);
                }
                return new(false, resModel.Message);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Chapar " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(GetPishroPostPriceQuery request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            var serializedModel = JsonConvert.SerializeObject(request);
            var model = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("input", serializedModel.ToString()),
            });

            var pUrl = new Uri($"{_gateway.BaseUrl}/get_quote");
            return await client.PostAsync(pUrl, model);
        }
    }
}
