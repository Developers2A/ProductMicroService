using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.CourierServices.PishroPost;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;

namespace Postex.Product.Application.Features.ServiceProviders.PishroPost.Commands.CreateOrder
{
    public class CreatePishroPostOrderCommandHandler : IRequestHandler<CreatePishroPostOrderCommand, BaseResponse<PishroPostCreateOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public CreatePishroPostOrderCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Chapar;
        }

        public async Task<BaseResponse<PishroPostCreateOrderResponse>> Handle(CreatePishroPostOrderCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<PishroPostCreateOrderResponse> result = new();
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);
                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<PishroPostCreateOrderResponse>(res);
                if (resModel!.Result)
                {
                    return new(true, "success", resModel);
                }

                return new(false, resModel.Message.ToString());
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service chapar " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(CreatePishroPostOrderCommand request)
        {
            request.User = new PishroPostUser();

            if (request.Bulk.First().cn.payment_term == "1")//COD
            {
                request.User.Username = "postkhone.cod";
                request.User.Password = "popo2021";
            }
            else
            {
                request.User.Username = _gateway.UserName;
                request.User.Password = _gateway.Password;
            }

            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            var serializedModel = JsonConvert.SerializeObject(request);
            var model = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("input", serializedModel.ToString()),
            });

            var pUrl = new Uri($"{_gateway.BaseUrl}/bulk_import");
            return await client.PostAsync(pUrl, model);
        }
    }
}
