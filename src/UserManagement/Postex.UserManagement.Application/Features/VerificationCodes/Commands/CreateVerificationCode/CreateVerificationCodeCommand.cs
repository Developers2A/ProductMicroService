using Postex.UserManagement.Application.Contracts;

namespace Postex.Application.Features.VerificationCodes.Commands.CreateVerificationCode;

public class CreateVerificationCodeCommand : ITransactionRequest
{
    public string Mobile { get; set; }
}
