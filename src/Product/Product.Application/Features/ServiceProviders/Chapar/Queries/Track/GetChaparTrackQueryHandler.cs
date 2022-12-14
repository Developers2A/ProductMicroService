using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Chapar;

namespace Product.Application.Features.ServiceProviders.Chapar.Queries.Track
{
    public class GetChaparTrackQueryHandler : IRequestHandler<GetChaparTrackQuery, BaseResponse<ChaparTrackResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetChaparTrackQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Chapar;
        }

        public async Task<BaseResponse<ChaparTrackResponse>> Handle(GetChaparTrackQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<ChaparTrackResponse> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);
                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }
                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<ChaparTrackResponse>(res);
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
        private async Task<HttpResponseMessage> SetHttpRequest(GetChaparTrackQuery request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            var serializedModel = JsonConvert.SerializeObject(request);
            var model = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("input", serializedModel.ToString()),
            });

            var pUrl = new Uri($"{_gateway.BaseUrl}/tracking");
            return await client.PostAsync(pUrl, model);
        }
    }
}
