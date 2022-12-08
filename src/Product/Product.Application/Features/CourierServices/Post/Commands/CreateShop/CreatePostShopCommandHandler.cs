using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.Post;
using Product.Application.Features.CourierServices.Post.Queries.GetToken;
using System.Text;

namespace Product.Application.Features.CourierServices.Post.Commands.CreateShop
{
    public class CreatePostShopCommandHandler : IRequestHandler<CreatePostShopCommand, BaseResponse<PostCreateShopResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;
        private readonly IMediator _mediator;

        public CreatePostShopCommandHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Post;
            _mediator = mediator;
        }

        public async Task<BaseResponse<PostCreateShopResponse>> Handle(CreatePostShopCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<PostCreateShopResponse> result = new();
            try
            {
                string token = await _mediator.Send(new GetPostTokenQuery());
                HttpResponseMessage response = await SetHttpRequest(token, request);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                try
                {
                    var resModel = JsonConvert.DeserializeObject<PostResponse<PostCreateShopResponse>>(res);
                    if (resModel!.ResCode == 0)
                    {
                        return new(true, "success", resModel.Data);
                    }

                    result = new(false, resModel!.ResMsg, resModel.Data);
                }
                catch
                {
                    var resModel = JsonConvert.DeserializeObject<PostEmptyResponse>(res);
                    if (resModel!.ResCode == 2)
                    {
                        return new(false, resModel.ResMsg + "," + resModel.Data != null ? string.Join<string>(",", resModel.Data!.Select(x => x.ErrorMessage)) : "");
                    }
                    return new(false, resModel.ResMsg);
                }
            }
            catch (Exception ex)
            {
                result = new(false, "An error has occurred in the Service Post " + ex.Message);
            }
            return result;
        }

        private async Task<HttpResponseMessage> SetHttpRequest(string token, CreatePostShopCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl, token);

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}Shop/Register");
            var response = await client.PostAsync(pUrl, content);
            return response;
        }
    }
}
