using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Pudo.Application.Dtos.DigikalaPudo;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Net.Http.Headers;

namespace Postex.Pudo.Application.Features.Digikala.Queries.GetPackages;

public class GetDigikalaPackagesQueryHandler : IRequestHandler<GetDigikalaPackagesQuery, BaseResponse<DigikalaPackageDto>>
{
    private readonly IConfiguration _configuration;
    private readonly CourierConfig _gateway;
    private readonly IMediator _mediator;

    public GetDigikalaPackagesQueryHandler(IConfiguration configuration, IMediator mediator)
    {
        _configuration = configuration;
        _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().DigikalaPudo;
        _mediator = mediator;
    }

    public async Task<BaseResponse<DigikalaPackageDto>> Handle(GetDigikalaPackagesQuery request, CancellationToken cancellationToken)
    {
        DigikalaPackageDto result = new();
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
                var resModel = JsonConvert.DeserializeObject<DigikalaPackageDto>(res);
                return new(true, "success", resModel!);
            }
            catch
            {
                return new(false, "");
            }
        }
        catch (Exception ex)
        {
            return new(false, "An error has occurred in the Service Pudo " + ex.Message);
        }
    }

    private async Task<HttpResponseMessage> SetHttpRequest(GetDigikalaPackagesQuery request)
    {
        HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
        client.DefaultRequestHeaders.Authorization =
          new AuthenticationHeaderValue("Authorization", _gateway.Token);

        //client.Timeout = -1;
        var pUrl = new Uri($"{_gateway.BaseUrl}last-mile/packages?start_date={request.StartDate}&end_date={request.EndDate}");
        var response = await client.GetAsync(pUrl);
        return response;
    }
}
