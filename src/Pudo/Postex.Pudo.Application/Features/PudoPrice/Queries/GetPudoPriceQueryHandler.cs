using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Pudo.Application.Dtos.PudoPrice;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.Pudo.Application.Features.PudoPrice.Queries;

public class GetPudoPriceQueryHandler : IRequestHandler<GetPudoPriceQuery, BaseResponse<PudoPriceDto>>
{
    private readonly IConfiguration _configuration;
    private readonly CourierConfig _gateway;
    private readonly IMediator _mediator;

    public GetPudoPriceQueryHandler(IConfiguration configuration, IMediator mediator)
    {
        _configuration = configuration;
        _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().DigikalaPudo;
        _mediator = mediator;
    }

    public async Task<BaseResponse<PudoPriceDto>> Handle(GetPudoPriceQuery request, CancellationToken cancellationToken)
    {
        BaseResponse<PudoPriceDto> result = new();
        try
        {
            HttpResponseMessage response = await SetHttpRequest(request);

            if (!response.IsSuccessStatusCode)
            {
                return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
            }

            var res = await response.Content.ReadAsStringAsync();
            try
            {
                var resModel = JsonConvert.DeserializeObject<PudoPriceDto>(res);
                return new(true, "success", resModel!);
            }
            catch
            {
                return new(false, "fail");
            }
        }
        catch (Exception ex)
        {
            return new(false, "An error has occurred in the Service Pudo Price " + ex.Message);
        }
    }

    private async Task<HttpResponseMessage> SetHttpRequest(GetPudoPriceQuery request)
    {
        HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);

        var serializedModel = JsonConvert.SerializeObject(request);
        var content = new StringContent(serializedModel,
            Encoding.UTF8,
            "application/json");

        var pUrl = new Uri($"{_gateway.BaseUrl}price/pudo-price?cityName={request.CityName}");
        var response = await client.PostAsync(pUrl, content);
        return response;
    }
}
