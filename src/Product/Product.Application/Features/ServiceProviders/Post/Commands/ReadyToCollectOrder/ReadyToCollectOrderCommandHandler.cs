using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Post;
using Product.Application.Features.ServiceProviders.Post.Queries.GetToken;
using System.Text;

namespace Product.Application.Features.ServiceProviders.Post.Commands.ReadyToCollectOrder
{
    public class ReadyToCollectOrderCommandHandler : IRequestHandler<ReadyToCollectOrderCommand, BaseResponse<List<PostReadyToCollectResponse>>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;
        private readonly IMediator _mediator;

        public ReadyToCollectOrderCommandHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Post;
            _mediator = mediator;
        }

        public async Task<BaseResponse<List<PostReadyToCollectResponse>>> Handle(ReadyToCollectOrderCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<List<PostReadyToCollectResponse>> result = new();
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
                    var resModel = JsonConvert.DeserializeObject<PostResponse<List<PostReadyToCollectResponse>>>(res);
                    if (resModel!.ResCode == 0)
                    {
                        return new(true, "success", resModel.Data);
                    }

                    return new(false, "fail", resModel.Data);
                }
                catch
                {
                    var resModel = JsonConvert.DeserializeObject<PostEmptyResponse>(res);
                    if (resModel!.ResCode == 2)
                    {
                        return new(false, resModel.ResMsg + "," + string.Join<string>(",", resModel!.Data.Select(x => x.ErrorMessage)), null);
                    }
                    return new(false, resModel!.ResMsg);
                }
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Post " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(string token, ReadyToCollectOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl, token);

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}Parcel/ReadyToCollect");
            var response = await client.PostAsync(pUrl, content);
            return response;
        }
    }
}
