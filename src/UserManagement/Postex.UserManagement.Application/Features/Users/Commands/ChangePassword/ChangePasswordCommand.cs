using Postex.SharedKernel.Api;
using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Application.Dtos.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.ChangePassword
{
    public class ChangePasswordCommand : ITransactionRequest<ApiResult<TokenDto>>
    {
        public string Mobile { get; set; }
        public string NewPassword { get; set; }
    }
}
