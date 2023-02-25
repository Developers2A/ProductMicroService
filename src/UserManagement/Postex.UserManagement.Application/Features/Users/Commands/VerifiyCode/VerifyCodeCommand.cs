using Postex.SharedKernel.Api;
using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.VerifiyCode;

public class VerifyCodeCommand : ITransactionRequest<ApiResult<TokenDto>>
{
    public string Mobile { get; set; }
    public int Code { get; set; }
    public VerificationCodeType VerificationCodeType { get; set; }
}
