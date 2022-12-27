using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Taroff.Dtos;
using System.Text;

namespace Product.Application.Features.ServiceProviders.Taroff.Commands.CreateOrder
{
    public class CreateTaroffOrderCommandHandler : IRequestHandler<CreateTaroffOrderCommand, BaseResponse<TaroffCreateOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public CreateTaroffOrderCommandHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Taroff;
        }

        public async Task<BaseResponse<TaroffCreateOrderResponse>> Handle(CreateTaroffOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();

                var resModel = JsonConvert.DeserializeObject<TaroffCreateOrderResponse>(res);
                if (resModel!.Status == "ok")
                {
                    return new(true, "success", resModel);
                }

                return new(false, resModel.Status);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Taroff " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(CreateTaroffOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            request.Token = _gateway.Token;
            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");
            var pUrl = new Uri($"{_gateway.BaseUrl}/Order/CreateOrder");

            return await client.PostAsync(pUrl, content);
        }
    }
}
