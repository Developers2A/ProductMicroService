using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.Link;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Net.Http.Headers;
using System.Text;

namespace Postex.Product.Application.Features.ServiceProviders.Link.Commands.CreateOrder
{
    public class CreateLinkOrderCommandHandler : IRequestHandler<CreateLinkOrderCommand, BaseResponse<LinkCreateOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public CreateLinkOrderCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Link;
        }

        public async Task<BaseResponse<LinkCreateOrderResponse>> Handle(CreateLinkOrderCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<LinkCreateOrderResponse> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);
                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<LinkCreateOrderResponse>(res);
                if (resModel!.Code == 0)
                {
                    return new(true, "success", resModel);
                }
                else
                {
                    return new(false, resModel.Message, resModel);
                }
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service bsw " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(CreateLinkOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            var byteArray = Encoding.ASCII.GetBytes($"{_gateway.UserName}:{_gateway.Password}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            client.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", _gateway.Token);
            var pUrl = new Uri($"{_gateway.BaseUrl}/add");
            return await client.PostAsync(pUrl, content);
        }
    }
}
