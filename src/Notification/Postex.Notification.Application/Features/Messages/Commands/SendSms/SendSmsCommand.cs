using Postex.Notification.Application.Contracts;

namespace Postex.Notification.Application.Features.Messages.Commands.SendSms
{
    public class SendSmsCommand : ITransactionRequest
    {
        public string Template { get; set; }
        public string Mobile { get; set; }
        public string Code { get; set; }
    }
}
