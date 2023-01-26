using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.CourierServices.PishroPost;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;

namespace Postex.Product.Application.Features.ServiceProviders.PishroPost.Commands.CancelOrder
{
    public class CancelPishroPostOrderCommandHandler : IRequestHandler<CancelPishroPostOrderCommand, BaseResponse<PishroPostCancelOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public CancelPishroPostOrderCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().PishroPost;
        }

        public async Task<BaseResponse<PishroPostCancelOrderResponse>> Handle(CancelPishroPostOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();

                var resModel = JsonConvert.DeserializeObject<PishroPostCancelOrderResponse>(res);
                if (resModel!.Result)
                {
                    return new(true, "success", resModel);
                }

                return new(false, resModel.Message.ToString());
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service PishroPost " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(CancelPishroPostOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            var serializedModel = JsonConvert.SerializeObject(request);
            var model = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("input", serializedModel.ToString()),
                });

            var pUrl = new Uri($"{_gateway.BaseUrl}/cancel_pickup");
            return await client.PostAsync(pUrl, model);
        }
    }
}
