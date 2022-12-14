using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Kbk.Dtos;
using System.Text;

namespace Product.Application.Features.ServiceProviders.Kbk.Commands.CancelOrder
{
    public class CancelKbkOrderCommandHandler : IRequestHandler<CancelKbkOrderCommand, BaseResponse<KbkCancelResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public CancelKbkOrderCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Kbk;
        }

        public async Task<BaseResponse<KbkCancelResponse>> Handle(CancelKbkOrderCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<KbkCancelResponse> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);
                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<KbkCancelResponse>(res);
                if (resModel != null)
                {
                    return new(true, "success", resModel);
                }

                return new(false, "fail");
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service chapar " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(CancelKbkOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);

            request.ApiCode = "e3f2e79dc6b0fac0b4c336e66feab57b";
            var pUrl = new Uri($"{_gateway.BaseUrl}?postexApi=1");

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
               Encoding.UTF8,
               "application/json");

            return await client.PostAsync(pUrl, content);
        }
    }
}
