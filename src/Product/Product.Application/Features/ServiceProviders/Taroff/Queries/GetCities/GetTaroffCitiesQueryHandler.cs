using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Taroff.Dtos;
using System.Text;

namespace Product.Application.Features.ServiceProviders.Taroff.Queries.GetCities
{
    public class GetTaroffCitiesQueryHandler : IRequestHandler<GetTaroffCitiesQuery, BaseResponse<List<TaroffState>>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetTaroffCitiesQueryHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Taroff;
        }

        public async Task<BaseResponse<List<TaroffState>>> Handle(GetTaroffCitiesQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<List<TaroffState>> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();

                var resModel = JsonConvert.DeserializeObject<TaroffGetCityResponse>(res);
                if (resModel!.State == "ok")
                {
                    result = new(true, "success", resModel.Categories);
                }

                return new(false, resModel.State);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Taroff " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(GetTaroffCitiesQuery request)
        {
            var client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);

            request.Token = _gateway.Token;

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}/City/Cities");
            return await client.PostAsync(pUrl, content);
        }
    }
}
