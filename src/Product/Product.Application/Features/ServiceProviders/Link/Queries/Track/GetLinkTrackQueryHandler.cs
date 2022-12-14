using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Link;
using System.Net.Http.Headers;
using System.Text;

namespace Product.Application.Features.ServiceProviders.Link.Queries.Track
{
    public class GetLinkTrackQueryHandler : IRequestHandler<GetLinkTrackQuery, BaseResponse<LinkTrackResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetLinkTrackQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Chapar;
        }

        public async Task<BaseResponse<LinkTrackResponse>> Handle(GetLinkTrackQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<LinkTrackResponse> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);
                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<LinkTrackResponse>(res);
                if (resModel!.Code == 0)
                {
                    return new(true, "success", resModel);
                }

                return new(false, "fail");
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Link " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(GetLinkTrackQuery request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            var byteArray = Encoding.ASCII.GetBytes($"{_gateway.UserName}:{_gateway.Password}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            client.DefaultRequestHeaders
               .Accept
               .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}/status");
            return await client.PostAsync(pUrl, content);
        }
    }
}
