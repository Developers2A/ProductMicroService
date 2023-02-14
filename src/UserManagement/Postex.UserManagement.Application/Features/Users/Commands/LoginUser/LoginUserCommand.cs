using Postex.SharedKernel.Api;
using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Application.Dtos.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.LoginUser;

public class LoginUserCommand : ITransactionRequest<ApiResult<TokenDto>>
{
    public string Mobile { get; set; }
    public string Password { get; set; }
}
