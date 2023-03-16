using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Pudo.Application.Dtos.PudoPrice;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.Pudo.Application.Features.PudoPrice.Queries;

public class GetPudoPriceQueryHandler : IRequestHandler<GetPudoPriceQuery, BaseResponse<PudoPriceDto>>
{
    private readonly IConfiguration _configuration;
    private readonly string _productApiUrl;
    private readonly IMediator _mediator;

    public GetPudoPriceQueryHandler(IConfiguration configuration, IMediator mediator)
    {
        _configuration = configuration;
        _productApiUrl = _configuration.GetSection(nameof(ApiSetting)).Get<ApiSetting>().ProductApi;
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
        if (string.IsNullOrEmpty(_productApiUrl))
        {
            throw new AppException("امکان اتصال به سرویس کاربران وجود ندارد");
        }

        HttpClient client = HttpClientUtilities.SetHttpClient(_productApiUrl);

        var serializedModel = JsonConvert.SerializeObject(request);
        var content = new StringContent(serializedModel,
            Encoding.UTF8,
            "application/json");

        var pUrl = new Uri($"{_productApiUrl}v1/price/pudo-price?cityName={request.CityName}");
        var response = await client.PostAsync(pUrl, content);
        return response;
    }
}
