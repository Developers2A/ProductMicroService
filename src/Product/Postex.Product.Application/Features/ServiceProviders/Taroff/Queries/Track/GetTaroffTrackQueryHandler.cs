using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.CourierServices.Taroff.Dtos;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.Product.Application.Features.ServiceProviders.Taroff.Queries.Track
{
    public class GetTaroffTrackQueryHandler : IRequestHandler<GetTaroffTrackQuery, BaseResponse<TaroffTrackResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetTaroffTrackQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Taroff;
        }

        public async Task<BaseResponse<TaroffTrackResponse>> Handle(GetTaroffTrackQuery request, CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<TaroffTrackResponse>(res);
                if (resModel!.State == "ok")
                {
                    return new(true, "success", resModel);
                }

                return new(false, resModel.State, resModel);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Taroff " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(GetTaroffTrackQuery request)
        {
            var client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);

            request.Token = _gateway.Token;

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}/Order/GetState");
            return await client.PostAsync(pUrl, content);
        }
    }
}
