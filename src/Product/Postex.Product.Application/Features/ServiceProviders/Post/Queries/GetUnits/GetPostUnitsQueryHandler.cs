using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetToken;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetUnits
{
    public class GetTokenQueryHandler : IRequestHandler<GetPostUnitsQuery, BaseResponse<List<PostGetUnitsResponse>>>
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

        public async Task<BaseResponse<List<PostGetUnitsResponse>>> Handle(GetPostUnitsQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<List<PostGetUnitsResponse>> result = new();
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
                    var resModel = JsonConvert.DeserializeObject<PostResponse<List<PostGetUnitsResponse>>>(res);
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

        private async Task<HttpResponseMessage> SetHttpRequest(string token, GetPostUnitsQuery request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl, token);
            var pUrl = new Uri($"{_gateway.BaseUrl}BaseInfo/PostUnits?provinceId={request.ProvinceId}");
            var response = await client.GetAsync(pUrl);
            return response;
        }
    }
}
