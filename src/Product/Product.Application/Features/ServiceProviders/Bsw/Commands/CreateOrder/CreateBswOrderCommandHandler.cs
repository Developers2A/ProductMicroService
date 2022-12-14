using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Bsw;
using System.Net.Http.Headers;
using System.Text;

namespace Product.Application.Features.ServiceProviders.Bsw.Commands.CreateOrder
{
    public class CreateBswOrderCommandHandler : IRequestHandler<CreateBswOrderCommand, BaseResponse<BswCreateOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public CreateBswOrderCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Bsw;
        }

        public async Task<BaseResponse<BswCreateOrderResponse>> Handle(CreateBswOrderCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<BswCreateOrderResponse> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);
                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<BswCreateOrderResponse>(res);
                if (string.IsNullOrEmpty(resModel!.errorMessage))
                {
                    return new(true, "success", resModel);
                }

                return new(false, "fail", resModel);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service bsw " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(CreateBswOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            client.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", _gateway.Token);
            var pUrl = new Uri($"{_gateway.BaseUrl}/RegisterOrder");
            return await client.PostAsync(pUrl, content);
        }
    }
}
