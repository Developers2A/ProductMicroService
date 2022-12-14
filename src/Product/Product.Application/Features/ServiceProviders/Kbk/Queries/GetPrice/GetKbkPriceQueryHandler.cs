using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Kbk.Dtos;
using System.Text;

namespace Product.Application.Features.ServiceProviders.Kbk.Queries.GetPrice
{
    public class GetKbkPriceQueryHandler : IRequestHandler<GetKbkPriceQuery, BaseResponse<KbkGetPriceResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetKbkPriceQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Chapar;
        }

        public async Task<BaseResponse<KbkGetPriceResponse>> Handle(GetKbkPriceQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<KbkGetPriceResponse> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);
                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<KbkGetPriceResponse>(res);
                if (resModel!.ErrorCode == null)
                {
                    return new(true, "success", resModel);
                }

                return new(false, "fail", resModel);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Chapar " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(GetKbkPriceQuery request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            request.ApiCode = "5d184f99571b34d62f8aa07186e289d2";
            var pUrl = new Uri($"{_gateway.BaseUrl}?postexApi=1");

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
               Encoding.UTF8,
               "application/json");
            return await client.PostAsync(pUrl, content);
        }
    }
}
