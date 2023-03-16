using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.Users;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Settings;

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
                var resModel = JsonConvert.DeserializeObject<BaseResponse<UserDto>>(res);
                return resModel!;
            }
            catch
            {
                return new(false, "fail");
            }
        }
        catch (Exception ex)
        {
            return new(false, "An error has occurred in the Service UserManagement " + ex.Message);
        }
    }

    private async Task<HttpResponseMessage> SetHttpRequest(GetUserByIdQuery request)
    {
        if (string.IsNullOrEmpty(_userApiUrl))
        {
            throw new AppException("امکان اتصال به سرویس کاربران وجود ندارد");
        }

        HttpClient client = HttpClientUtilities.SetHttpClient(_userApiUrl);

        var pUrl = new Uri($"{_userApiUrl}v1/user?id={request.UserId}");
        var response = await client.GetAsync(pUrl);
        return response;
    }
}
