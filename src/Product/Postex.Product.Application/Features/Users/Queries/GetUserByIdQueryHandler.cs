using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.Users;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.Product.Application.Features.Users.Queries;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, BaseResponse<UserDto>>
{
    private readonly IConfiguration _configuration;
    private readonly string? _userApiUrl;
    private readonly IMediator _mediator;

    public GetUserByIdQueryHandler(IConfiguration configuration, IMediator mediator)
    {
        _configuration = configuration;
        _userApiUrl = _configuration.GetSection(nameof(ApiSetting)).Get<ApiSetting>().UserApi;
        _mediator = mediator;
    }

    public async Task<BaseResponse<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
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
                var resModel = JsonConvert.DeserializeObject<UserDto>(res);
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

    private async Task<HttpResponseMessage> SetHttpRequest(GetUserByIdQuery request)
    {
        if (string.IsNullOrEmpty(_userApiUrl))
        {
            throw new AppException("امکان اتصال به سرویس کاربران وجود ندارد");
        }

        HttpClient client = HttpClientUtilities.SetHttpClient(_userApiUrl);

        var serializedModel = JsonConvert.SerializeObject(request);
        var content = new StringContent(serializedModel,
            Encoding.UTF8,
            "application/json");

        var pUrl = new Uri($"{_userApiUrl}user?id={request.UserId}");
        var response = await client.PostAsync(pUrl, content);
        return response;
    }
}
