using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.CourierServices.Mahex;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Net.Http.Headers;
using System.Text;

namespace Postex.Product.Application.Features.ServiceProviders.Mahex.Commands.CreateOrder
{
    public class CreateMahexOrderCommandHandler : IRequestHandler<CreateMahexOrderCommand, BaseResponse<MahexCreateOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public CreateMahexOrderCommandHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Mahex;
        }

        public async Task<BaseResponse<MahexCreateOrderResponse>> Handle(CreateMahexOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();

                var resModel = JsonConvert.DeserializeObject<MahexCreateOrderResponse>(res);
                if (resModel!.Status.Code == 200 || resModel.Status.Code == 201)
                {
                    return new(true, "success", resModel);
                }

                return new(false, resModel!.Status.Message!);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Mahex " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(CreateMahexOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _gateway.Token);

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}/shipments");
            var response = await client.PostAsync(pUrl, content);
            return response;
        }
    }
}
