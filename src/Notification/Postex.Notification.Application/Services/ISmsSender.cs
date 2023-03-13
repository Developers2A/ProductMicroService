using Kavenegar.Core.Models;

namespace Postex.Notification.Application.Services;

public interface ISmsSender
{
    Task<SendResult> SendSms(List<string> mobile, string message);
    Task<SendResult> SendSms(List<string> mobile, string template, Dictionary<string, string> values);
}
