using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Bsw;
using System.Net.Http.Headers;
using System.Text;

namespace Product.Application.Features.ServiceProviders.Bsw.Queries.Track
{
    public class TrackBswCommandHandler : IRequestHandler<TrackBswCommand, BaseResponse<List<BswTrackResponseDto>>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public TrackBswCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Bsw;
        }

        public async Task<BaseResponse<List<BswTrackResponseDto>>> Handle(TrackBswCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<BswTrackResponseDto> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);
                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<List<BswTrackResponseDto>>(res);
                return new(true, "success", resModel);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service bsw " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(TrackBswCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            client.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", _gateway.Token);
            var pUrl = new Uri($"{_gateway.BaseUrl}/CancelOrder");
            return await client.PostAsync(pUrl, content);
        }
    }
}
