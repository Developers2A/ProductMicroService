using Postex.Notification.Application.Contracts;

namespace Postex.Notification.Application.Features.Messages.Commands.SendSms;

public class SendSmsCommand : ITransactionRequest
{
    public int? TemplateId { get; set; }
    public string Mobile { get; set; }
    public string? Message { get; set; }
    public Dictionary<string, string>? Parameters { get; set; }
}
