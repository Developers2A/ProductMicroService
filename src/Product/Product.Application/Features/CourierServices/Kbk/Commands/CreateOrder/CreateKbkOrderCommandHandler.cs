using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Chapar;
using Product.Application.Dtos.CourierServices.Kbk.Dtos;
using System.Text;

namespace Product.Application.Features.CourierServices.Kbk.Commands.CreateOrder
{
    public class CreateKbkOrderCommandHandler : IRequestHandler<CreateKbkOrderCommand, BaseResponse<KbkCreateOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public CreateKbkOrderCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Chapar;
        }

        public async Task<BaseResponse<KbkCreateOrderResponse>> Handle(CreateKbkOrderCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<ChaparCreateOrderResponse> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);
                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<KbkCreateOrderResponse>(res);
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

        private async Task<HttpResponseMessage> SetHttpRequest(CreateKbkOrderCommand request)
        {
            System.Net.Http.HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);

            request.apiCode = "32e5ddaad52dee1a0cd1c6279ea5d436";
            var pUrl = new Uri($"{_gateway.BaseUrl}?postexApi=1");

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
               Encoding.UTF8,
               "application/json");

            return await client.PostAsync(pUrl, content);
        }
    }
}
