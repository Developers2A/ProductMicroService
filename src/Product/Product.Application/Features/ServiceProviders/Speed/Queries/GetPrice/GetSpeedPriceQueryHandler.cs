using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Post;
using Product.Application.Dtos.CourierServices.Speed.Dtos;
using Product.Application.Features.CourierServices.Post.Queries.GetToken;
using System.Net.Http.Headers;
using System.Text;

namespace Product.Application.Features.ServiceProviders.Speed.Queries.GetPrice
{
    public class GetSpeedPriceQueryHandler : IRequestHandler<GetSpeedPriceQuery, BaseResponse<SpeedGetPriceResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;
        private readonly IMediator _mediator;

        public GetSpeedPriceQueryHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Post;
            _mediator = mediator;
        }

        public async Task<BaseResponse<SpeedGetPriceResponse>> Handle(GetSpeedPriceQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<PostGetPriceResponse> result = new();
            try
            {
                string token = await _mediator.Send(new GetPostTokenQuery());
                HttpResponseMessage response = await SetHttpRequest(token, request);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();

                var resModel = JsonConvert.DeserializeObject<SpeedGetPriceResponse>(res);
                if (resModel.ErrorCode == 0)
                {
                    return new(true, "success", resModel);
                }
                return new(false, resModel.Error, resModel);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Speed " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(string token, GetSpeedPriceQuery request)
        {
            var client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);

            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            request.Key = _gateway.Token;

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}/Priceinquiry");
            return await client.PostAsync(pUrl, content);
        }
    }
}
