using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Mahex;
using System.Net.Http.Headers;

namespace Product.Application.Features.ServiceProviders.Mahex.Queries.Track
{
    public class GetMahexTrackQueryHandler : IRequestHandler<GetMahexTrackQuery, BaseResponse<MahexTrackResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetMahexTrackQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Mahex;
        }

        public async Task<BaseResponse<MahexTrackResponse>> Handle(GetMahexTrackQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var client = SetHttpRequest();
                var pUrl = new Uri($"{_gateway.BaseUrl}");

                if (!string.IsNullOrEmpty(request.WaybillNumber))
                {
                    pUrl = new Uri($"{_gateway.BaseUrl}/track/{request.WaybillNumber}");
                }
                else if (!string.IsNullOrEmpty(request.Reference))
                {
                    pUrl = new Uri($"{_gateway.BaseUrl}/track/reference/{request.Reference}");
                }
                else
                {
                    pUrl = new Uri($"{_gateway.BaseUrl}/track/partnumber/{request.PartNumber}");
                }

                var response = await client.GetAsync(pUrl);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString());
                }

                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<MahexTrackResponse>(res);
                if (resModel!.Status.Code == 200 || resModel.Status.Code == 201)
                {
                    return new(true, "success", resModel);
                }

                return new(false, resModel.Status.Message, resModel);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Track Mahex " + ex.Message);
            }
        }

        private HttpClient SetHttpRequest()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(_gateway.BaseUrl)
            };

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", _gateway.Token);

            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
