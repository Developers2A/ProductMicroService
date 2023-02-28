using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.Speed.Dtos;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.Product.Application.Features.ServiceProviders.Speed.Commands.CreateOrder
{
    public class CreateSpeedOrderCommandHandler : IRequestHandler<CreateSpeedOrderCommand, BaseResponse<SpeedCreateOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public CreateSpeedOrderCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Speed;
        }

        public async Task<BaseResponse<SpeedCreateOrderResponse>> Handle(CreateSpeedOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();

                var resModel = JsonConvert.DeserializeObject<SpeedCreateOrderResponse>(res);
                if (resModel!.ErrorCode == 0)
                {
                    return new(true, "success", resModel);
                }

                return new(false, resModel.Msg + " " + resModel.Error);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Speed " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(CreateSpeedOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            request.Key = _gateway.Token;
            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}/SpecialImport");
            var response = await client.PostAsync(pUrl, content);
            return response;
        }
    }
}
