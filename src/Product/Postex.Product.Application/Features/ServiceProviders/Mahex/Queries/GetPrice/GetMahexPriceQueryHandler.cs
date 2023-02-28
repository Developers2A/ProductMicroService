using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.Mahex;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Net.Http.Headers;
using System.Text;

namespace Postex.Product.Application.Features.ServiceProviders.Mahex.Queries.GetPrice
{
    public class GetMahexPriceQueryHandler : IRequestHandler<GetMahexPriceQuery, BaseResponse<MahexGetPriceResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetMahexPriceQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Mahex;
        }

        public async Task<BaseResponse<MahexGetPriceResponse>> Handle(GetMahexPriceQuery request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await SetHttpRequest(request);
            if (!response.IsSuccessStatusCode)
            {
                return new(false, response.StatusCode.ToString());
            }
            var res = await response.Content.ReadAsStringAsync();
            var resModel = JsonConvert.DeserializeObject<MahexGetPriceResponse>(res);
            if (resModel!.Status.Code == 200 || resModel.Status.Code == 201)
            {
                return new(true, "success", resModel);
            }

            return new(false, resModel.Status.Message, resModel);
        }

        private async Task<HttpResponseMessage> SetHttpRequest(GetMahexPriceQuery request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", _gateway.Token);

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}/rates");
            var response = await client.PostAsync(pUrl, content);
            return response;
        }
    }
}
