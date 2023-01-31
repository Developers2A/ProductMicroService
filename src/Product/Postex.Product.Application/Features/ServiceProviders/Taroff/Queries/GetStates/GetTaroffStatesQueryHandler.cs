using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.CourierServices.Taroff.Dtos;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;

namespace Postex.Product.Application.Features.ServiceProviders.Taroff.Queries.GetStates
{
    public class GetTokenQueryHandler : IRequestHandler<GetTaroffStatesQuery, BaseResponse<List<TaroffState>>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetTokenQueryHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Taroff;
        }

        public async Task<BaseResponse<List<TaroffState>>> Handle(GetTaroffStatesQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<TaroffGetProvincesResponse> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();

                var resModel = JsonConvert.DeserializeObject<TaroffGetProvincesResponse>(res);
                if (resModel!.State == "ok")
                {
                    return new(true, "success", resModel.Categories);
                }

                return new(false, "fail", resModel.Categories);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Tarrof " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(GetTaroffStatesQuery request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);

            request.Token = _gateway.Token;

            var pUrl = new Uri($"{_gateway.BaseUrl}/City/Provinces");
            var response = await client.GetAsync(pUrl);
            return response;
        }
    }
}
