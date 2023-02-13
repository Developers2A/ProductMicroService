using Postex.UserManagement.Application.Contracts;

namespace Postex.Application.Features.VerificationCodes.Commands.UpdateVerificationCode;

public class UpdateVerificationCodeCommand : ITransactionRequest
{
    public string Mobile { get; set; }
    public int Code { get; set; }
    public bool IsUsed { get; set; }
}
