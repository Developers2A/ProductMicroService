using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetToken;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Queries.Track
{
    public class GetPostTrackQueryHandler : IRequestHandler<GetPostTrackQuery, BaseResponse<PostTrackResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;
        private readonly IMediator _mediator;

        public GetPostTrackQueryHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Post;
            _mediator = mediator;
        }

        public async Task<BaseResponse<PostTrackResponse>> Handle(GetPostTrackQuery request, CancellationToken cancellationToken)
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
                    var resModel = JsonConvert.DeserializeObject<PostResponse<PostTrackResponse>>(res);
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

        private async Task<HttpResponseMessage> SetHttpRequest(string token, GetPostTrackQuery request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl, token);
            var pUrl = new Uri($"{_gateway.BaseUrl}Parcel/Track?parcelCode={request.ParcelCode}");
            var response = await client.GetAsync(pUrl);
            return response;
        }
    }
}
