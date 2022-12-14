using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Speed.Dtos;
using System.Net.Http.Headers;
using System.Text;

namespace Product.Application.Features.ServiceProviders.Speed.Queries.Track
{
    public class GetSpeedTrackQueryHandler : IRequestHandler<GetSpeedTrackQuery, BaseResponse<SpeedTrackResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetSpeedTrackQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Speed;
        }

        public async Task<BaseResponse<SpeedTrackResponse>> Handle(GetSpeedTrackQuery request, CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();

                var resModel = JsonConvert.DeserializeObject<SpeedTrackResponse>(res);
                if (resModel!.ErrorCode == 0)
                {
                    return new(true, "success", resModel);
                }

                return new(false, resModel.Error + " " + resModel.Msg, resModel);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Speed " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(GetSpeedTrackQuery request)
        {
            var client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);

            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var model = new
            {
                barcode = request.Barcode,
                key = _gateway.Token
            };

            var serializedModel = JsonConvert.SerializeObject(model);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}/EventCheck");
            return await client.PostAsync(pUrl, content);
        }
    }
}
