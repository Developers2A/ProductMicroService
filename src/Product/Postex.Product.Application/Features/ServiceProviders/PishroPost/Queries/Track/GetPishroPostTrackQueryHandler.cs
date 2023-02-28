using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.Chapar;
using Postex.Product.Application.Dtos.ServiceProviders.PishroPost;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;

namespace Postex.Product.Application.Features.ServiceProviders.PishroPost.Queries.Track
{
    public class GetPishroPostTrackQueryHandler : IRequestHandler<GetPishroPostTrackQuery, BaseResponse<PishroPostTrackResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetPishroPostTrackQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Chapar;
        }

        public async Task<BaseResponse<PishroPostTrackResponse>> Handle(GetPishroPostTrackQuery request, CancellationToken cancellationToken)
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
                var resModel = JsonConvert.DeserializeObject<PishroPostTrackResponse>(res);
                if (resModel!.Result)
                {
                    return new(true, "success", resModel);
                }
                return new(false, resModel.Message);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service PishroPost " + ex.Message);
            }
        }
        private async Task<HttpResponseMessage> SetHttpRequest(GetPishroPostTrackQuery request)
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
