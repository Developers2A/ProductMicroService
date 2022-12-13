using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Chapar;

namespace Product.Application.Features.CourierServices.Chapar.Queries.GetPrice
{
    public class GetChaparPriceQueryHandler : IRequestHandler<GetChaparPriceQuery, BaseResponse<ChaparGetPriceResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetChaparPriceQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Chapar;
        }

        public async Task<BaseResponse<ChaparGetPriceResponse>> Handle(GetChaparPriceQuery request, CancellationToken cancellationToken)
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

        private async Task<HttpResponseMessage> SetHttpRequest(GetChaparPriceQuery request)
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
