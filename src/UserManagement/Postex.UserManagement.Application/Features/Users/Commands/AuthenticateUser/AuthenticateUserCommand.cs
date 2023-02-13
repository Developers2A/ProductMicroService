using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Application.Dtos.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.AuthenticateUser;

public class AuthenticateUserCommand : ITransactionRequest<AuthenticateUserDto>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
