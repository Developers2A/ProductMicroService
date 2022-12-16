using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Post;
using Product.Application.Features.ServiceProviders.Post.Queries.GetToken;

namespace Product.Application.Features.ServiceProviders.Post.Queries.GetNodes
{
    public class GetTokenQueryHandler : IRequestHandler<GetPostNodesQuery, BaseResponse<List<PostGetNodesResponse>>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;
        private readonly IMediator _mediator;

        public GetTokenQueryHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Post;
            _mediator = mediator;
        }

        public async Task<BaseResponse<List<PostGetNodesResponse>>> Handle(GetPostNodesQuery request, CancellationToken cancellationToken)
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
                    var resModel = JsonConvert.DeserializeObject<PostResponse<List<PostGetNodesResponse>>>(res);
                    if (resModel!.ResCode == 0)
                    {
                        return new(true, "success", resModel.Data!);
                    }

                    return new(false, resModel.ResMsg!);
                }
                catch
                {
                    var resModel = JsonConvert.DeserializeObject<PostEmptyResponse>(res);
                    if (resModel!.ResCode == 2)
                    {
                        return new(false, resModel.ResMsg + "," + string.Join<string>(",", resModel.Data!.Select(x => x.ErrorMessage)), null);
                    }
                    return new(false, resModel.ResMsg!);
                }
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Post " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(string token, GetPostNodesQuery request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl, token);
            var pUrl = new Uri($"{_gateway.BaseUrl}BaseInfo/PostNode?cityId={request.CityId}");
            var response = await client.GetAsync(pUrl);
            return response;
        }
    }
}
