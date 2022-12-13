using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Taroff.Dtos;
using System.Text;

namespace Product.Application.Features.CourierServices.Taroff.Commands.ReadyOrder
{
    public class ReadyTaroffOrderCommandHandler : IRequestHandler<ReadyTaroffOrderCommand, BaseResponse<TaroffReadyOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public ReadyTaroffOrderCommandHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Taroff;
        }

        public async Task<BaseResponse<TaroffReadyOrderResponse>> Handle(ReadyTaroffOrderCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<TaroffDeleteResponse> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();

                var resModel = JsonConvert.DeserializeObject<TaroffReadyOrderResponse>(res);
                if (resModel!.State == "ok")
                {
                    return new(true, "success", resModel);
                }

                return new(false, resModel.State);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Taroff " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(ReadyTaroffOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}/order/SetStateReady");
            var response = await client.PostAsync(pUrl, content);
            return response;
        }
    }
}
