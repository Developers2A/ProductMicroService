using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetToken;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Commands.DeleteOrder
{
    public class DeletePostOrderCommandHandler : IRequestHandler<DeletePostOrderCommand, BaseResponse<List<PostDeleteOrderResponse>>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;
        private readonly IMediator _mediator;

        public DeletePostOrderCommandHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Post;
            _mediator = mediator;
        }

        public async Task<BaseResponse<List<PostDeleteOrderResponse>>> Handle(DeletePostOrderCommand request, CancellationToken cancellationToken)
        {
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
                    var resModel = JsonConvert.DeserializeObject<PostResponse<List<PostDeleteOrderResponse>>>(res);
                    if (resModel!.ResCode == 0)
                    {
                        return new(true, "success", resModel!.Data!);
                    }

                    return new(false, resModel.ResMsg!);
                }
                catch
                {
                    var resModel = JsonConvert.DeserializeObject<PostEmptyResponse>(res);
                    if (resModel!.ResCode == 2)
                    {
                        return new(false, resModel.Data != null ? string.Join<string>(",", resModel.Data!.Select(x => x.FieldName + " : " + x.ErrorMessage)) : resModel.ResMsg!);
                    }
                    return new(false, resModel.ResMsg!);
                }
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Post " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(string token, DeletePostOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl, token);

            var serializedModel = JsonConvert.SerializeObject(request.ParcelCodes);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}Parcel/Delete");
            var response = await client.PostAsync(pUrl, content);
            return response;
        }
    }
}
