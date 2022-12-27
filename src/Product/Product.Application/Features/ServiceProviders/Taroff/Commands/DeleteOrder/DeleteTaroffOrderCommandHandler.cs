using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Taroff.Dtos;
using System.Text;

namespace Product.Application.Features.ServiceProviders.Taroff.Commands.DeleteOrder
{
    public class DeleteTaroffOrderCommandHandler : IRequestHandler<DeleteTaroffOrderCommand, BaseResponse<TaroffDeleteResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public DeleteTaroffOrderCommandHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Taroff;
        }

        public async Task<BaseResponse<TaroffDeleteResponse>> Handle(DeleteTaroffOrderCommand command, CancellationToken cancellationToken)
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

                var resModel = JsonConvert.DeserializeObject<TaroffDeleteResponse>(res);
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

        private async Task<HttpResponseMessage> SetHttpRequest(DeleteTaroffOrderCommand command)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            command.Token = _gateway.Token;
            var serializedModel = JsonConvert.SerializeObject(command);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");
            var pUrl = new Uri($"{_gateway.BaseUrl}/order/delete");

            return await client.PostAsync(pUrl, content);
        }
    }
}
