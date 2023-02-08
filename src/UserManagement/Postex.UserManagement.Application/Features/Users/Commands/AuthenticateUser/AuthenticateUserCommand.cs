using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Application.Dtos.Users;

namespace Pouya.Application.Features.Users.Commands;

public class AuthenticateUserCommand : ITransactionRequest<AuthenticateUserDto>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
