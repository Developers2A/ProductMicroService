using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.Kbk;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.Product.Application.Features.ServiceProviders.Kbk.Queries.Track
{
    public class GetKbkTrackQueryHandler : IRequestHandler<GetKbkTrackQuery, BaseResponse<KbkTrackResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetKbkTrackQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Kbk;
        }

        public async Task<BaseResponse<KbkTrackResponse>> Handle(GetKbkTrackQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<KbkTrackResponse> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);
                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<KbkTrackResponse>(res);
                if (resModel != null && resModel.Status != null)
                {
                    return new(true, "success", resModel);
                }

                return new(false, "fail");
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Kalaresan " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(GetKbkTrackQuery request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            request.ApiCode = "fd888a2f67cdd457dc4fde46e50d7058";
            var pUrl = new Uri($"{_gateway.BaseUrl}?postexApi=1");

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
               Encoding.UTF8,
               "application/json");
            return await client.PostAsync(pUrl, content);
        }
    }
}
