using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.Customers;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Settings;

namespace Postex.Product.Application.Features.Customers.Queries;

public class GetCustomerByUserIdQueryHandler : IRequestHandler<GetCustomerByUserIdQuery, BaseResponse<CustomerDto>>
{
    private readonly IConfiguration _configuration;
    private readonly IMediator _mediator;
    private readonly string? _customerApiUrl;

    public GetCustomerByUserIdQueryHandler(IConfiguration configuration, IMediator mediator)
    {
        _configuration = configuration;
        _customerApiUrl = _configuration.GetSection(nameof(ApiSetting)).Get<ApiSetting>().UserApi;
        _mediator = mediator;
    }

    public async Task<BaseResponse<CustomerDto>> Handle(GetCustomerByUserIdQuery request, CancellationToken cancellationToken)
    {
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
                var resModel = JsonConvert.DeserializeObject<BaseResponse<CustomerDto>>(res);
                return resModel!;
            }
            catch
            {
                return new(false, "fail");
            }
        }
        catch (Exception ex)
        {
            return new(false, "An error has occurred in the Service user management " + ex.Message);
        }
    }

    private async Task<HttpResponseMessage> SetHttpRequest(GetCustomerByUserIdQuery request)
    {
        if (string.IsNullOrEmpty(_customerApiUrl))
        {
            throw new AppException("امکان اتصال به سرویس مشتریان وجود ندارد");
        }

        HttpClient client = HttpClientUtilities.SetHttpClient(_customerApiUrl);

        var pUrl = new Uri($"{_customerApiUrl}v1/customer/GetByUserId?userId={request.UserId}");
        var response = await client.GetAsync(pUrl);
        return response;
    }
}
