using Postex.SharedKernel.Api;
using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Application.Dtos.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.ForgetPassword
{
    public class ForgetPasswordCommand : ITransactionRequest<ApiResult<MobileDto>>
    {
        public string Mobile { get; set; }
    }
}
