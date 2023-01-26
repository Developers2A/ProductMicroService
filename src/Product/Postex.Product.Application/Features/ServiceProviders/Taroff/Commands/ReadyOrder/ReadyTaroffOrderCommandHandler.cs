using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.CourierServices.Taroff.Dtos;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.ReadyOrder
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

        public async Task<BaseResponse<TaroffReadyOrderResponse>> Handle(ReadyTaroffOrderCommand command, CancellationToken cancellationToken)
        {
            BaseResponse<TaroffDeleteResponse> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(command);

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

        private async Task<HttpResponseMessage> SetHttpRequest(ReadyTaroffOrderCommand command)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            command.Token = _gateway.Token;
            var serializedModel = JsonConvert.SerializeObject(command);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}/order/SetStateReady");
            return await client.PostAsync(pUrl, content);
        }
    }
}
