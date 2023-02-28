using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.Chapar;
using Postex.Product.Application.Dtos.ServiceProviders.Kbk.Dtos;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.Product.Application.Features.ServiceProviders.Kbk.Commands.CreateOrder
{
    public class CreateKbkOrderCommandHandler : IRequestHandler<CreateKbkOrderCommand, BaseResponse<KbkCreateOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public CreateKbkOrderCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Kbk;
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
                if (resModel!.ErrorCode != null && Convert.ToInt32(resModel!.ErrorCode) <= 4)
                {
                    return new(false, resModel.Message);
                }

                return new(true, "success", resModel);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service kbk " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(CreateKbkOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);

            request.ApiCode = "32e5ddaad52dee1a0cd1c6279ea5d436";
            var pUrl = new Uri($"{_gateway.BaseUrl}?postexApi=1");

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
               Encoding.UTF8,
               "application/json");

            return await client.PostAsync(pUrl, content);
        }
    }
}
