using Postex.UserManagement.Application.Contracts;

namespace Pouya.Application.Features.Users.Commands;

public class DeleteUserCommand : ITransactionRequest
{
    public int Id { get; set; }
}
