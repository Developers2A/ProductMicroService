using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Domain;

namespace Postex.UserManagement.Application.Features.Users.Commands.GenerateToken
{
    public class GenerateTokenCommand : ITransactionRequest<TokenDto>
    {
        public User User { get; set; }
    }
}
