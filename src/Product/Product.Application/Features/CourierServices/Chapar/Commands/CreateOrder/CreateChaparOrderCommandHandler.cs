using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.Chapar;
using Product.Application.Dtos.Chapar.Common;

namespace Product.Application.Features.CourierServices.Chapar.Commands.CreateOrder
{
    public class CreateChaparOrderCommandHandler : IRequestHandler<CreateChaparOrderCommand, BaseResponse<ChaparCreateOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public CreateChaparOrderCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Chapar;
        }

        public async Task<BaseResponse<ChaparCreateOrderResponse>> Handle(CreateChaparOrderCommand request, CancellationToken cancellationToken)
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
                var resModel = JsonConvert.DeserializeObject<ChaparCreateOrderResponse>(res);
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

        private async Task<HttpResponseMessage> SetHttpRequest(CreateChaparOrderCommand request)
        {
            request.User = new ChaparUser();

            if (request.Bulk.First().cn.payment_term == 1)//COD
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
