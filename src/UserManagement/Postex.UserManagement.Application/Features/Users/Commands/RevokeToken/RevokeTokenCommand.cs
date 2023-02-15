using Postex.UserManagement.Application.Contracts;

namespace Postex.UserManagement.Application.Features.Users.Commands.RevokeToken
{
    public class RevokeTokenCommand : ITransactionRequest
    {
        public Guid UserId { get; set; }
    }
}
