using Postex.UserManagement.Application.Contracts;

namespace Postex.UserManagement.Application.Features.Users.Commands.ForgetPassword
{
    public class ForgetPasswordCommand : ITransactionRequest
    {
        public string Mobile { get; set; }
    }
}
