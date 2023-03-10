using Kavenegar.Core.Models;

namespace Postex.Notification.Application.Services;

public interface ISmsSender
{
    Task<SendResult> SendSms(Dictionary<string, string> values, List<string> mobile, string template);
}
