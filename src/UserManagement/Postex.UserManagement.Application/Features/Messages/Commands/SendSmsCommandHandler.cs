using MediatR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.UserManagement.Application.Features.Messages.Commands;

public class SendSmsCommandHandler : IRequestHandler<SendSmsCommand>
{
    private readonly IMediator _mediator;
    private readonly ApiSetting _apiSetting;
    private readonly string? _notificationApiUrl;

    public SendSmsCommandHandler(
        IMediator mediator,
        IOptions<ApiSetting> apiSetting)
    {
        _mediator = mediator;
        _apiSetting = apiSetting.Value;
        _notificationApiUrl = _apiSetting.NotificationApi;
    }

    public async Task<Unit> Handle(SendSmsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            HttpResponseMessage response = await SetHttpRequest(request);

            await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
        }
        return Unit.Value;
    }

    private async Task<HttpResponseMessage> SetHttpRequest(SendSmsCommand request)
    {
        if (string.IsNullOrEmpty(_notificationApiUrl))
        {
            throw new AppException("امکان اتصال به سرویس نوتیفیکیشن وجود ندارد");
        }

        HttpClient client = HttpClientUtilities.SetHttpClient(_notificationApiUrl);

        var serializedModel = JsonConvert.SerializeObject(request);
        var content = new StringContent(serializedModel,
            Encoding.UTF8,
            "application/json");

        var pUrl = new Uri($"{_notificationApiUrl}v1/message");
        var response = await client.PostAsync(pUrl, content);
        return response;
    }
}
