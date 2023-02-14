using Postex.SharedKernel.Api;
using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Application.Dtos.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.RefreshToken
{
    public class RefreshTokenCommand : ITransactionRequest<ApiResult<TokenDto>>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
