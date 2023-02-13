using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Application.Dtos.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.VerifiyUser
{
    public class VerifyUserCommand : ITransactionRequest<AuthenticateUserDto>
    {
        public string Mobile { get; set; }
        public int Code { get; set; }
    }
}
