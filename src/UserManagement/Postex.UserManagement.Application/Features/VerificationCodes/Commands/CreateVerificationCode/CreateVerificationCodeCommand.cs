using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Domain;

namespace Postex.Application.Features.VerificationCodes.Commands.CreateVerificationCode;

public class CreateVerificationCodeCommand : ITransactionRequest
{
    public string Mobile { get; set; }
    public int? UserId { get; set; }
    public VerificationCodeType VerificationCodeType { get; set; }
}
