using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Post;
using Product.Application.Dtos.CourierServices.Speed.Dtos;
using Product.Application.Features.CourierServices.Post.Queries.GetToken;
using System.Text;

namespace Product.Application.Features.ServiceProviders.Speed.Commands.CreateOrder
{
    public class CreateSpeedOrderCommandHandler : IRequestHandler<CreateSpeedOrderCommand, BaseResponse<SpeedCreateOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;
        private readonly IMediator _mediator;

        public CreateSpeedOrderCommandHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Post;
            _mediator = mediator;
        }

        public async Task<BaseResponse<SpeedCreateOrderResponse>> Handle(CreateSpeedOrderCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<SpeedCreateOrderResponse> result = new();
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
                    var resModel = JsonConvert.DeserializeObject<SpeedCreateOrderResponse>(res);
                    if (resModel!.ErrorCode == 0)
                    {
                        return new(true, "success", resModel);
                    }

                    return new(false, resModel.Error);
                }
                catch
                {
                    var resModel = JsonConvert.DeserializeObject<PostEmptyResponse>(res);
                    if (resModel!.ResCode == 2)
                    {
                        return new(false, resModel.Data != null ? string.Join<string>(",", resModel.Data!.Select(x => x.ErrorMessage)) : resModel.ResMsg!);
                    }
                    return new(false, resModel.ResMsg!);
                }
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Post " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(string token, CreateSpeedOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl, token);
            request.Key = _gateway.Token;
            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}/SpecialImport");
            var response = await client.PostAsync(pUrl, content);
            return response;
        }
    }
}
