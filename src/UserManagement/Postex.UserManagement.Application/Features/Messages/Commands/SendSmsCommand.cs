using Postex.UserManagement.Application.Contracts;

namespace Postex.UserManagement.Application.Features.Messages.Commands;

public class SendSmsCommand : ITransactionRequest
{
    public string Mobile { get; set; }
    public string Code { get; set; }
    public string Template { get; set; }
}
