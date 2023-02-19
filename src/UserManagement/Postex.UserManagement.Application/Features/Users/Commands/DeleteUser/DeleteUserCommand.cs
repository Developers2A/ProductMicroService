using Postex.UserManagement.Application.Contracts;

namespace Postex.UserManagement.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : ITransactionRequest
{
    public int Id { get; set; }
}
