using Postex.UserManagement.Application.Contracts;

namespace Pouya.Application.Features.Users.Commands
{
    public class CreateUserCommand : ITransactionRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
