using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.Customers;
using Postex.Product.Application.Dtos.Users;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Settings;
using System.Text;

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
        BaseResponse<UserDto> result = new();
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
                var resModel = JsonConvert.DeserializeObject<CustomerDto>(res);
                return new(true, "success", resModel!);
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

        var serializedModel = JsonConvert.SerializeObject(request);
        var content = new StringContent(serializedModel,
            Encoding.UTF8,
            "application/json");

        var pUrl = new Uri($"{_customerApiUrl}customer/GetByUserId?userId={request.UserId}");
        var response = await client.PostAsync(pUrl, content);
        return response;
    }
}
