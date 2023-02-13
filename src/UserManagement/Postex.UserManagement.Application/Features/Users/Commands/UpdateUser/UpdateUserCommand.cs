using Postex.UserManagement.Application.Contracts;

namespace Postex.UserManagement.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : ITransactionRequest
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
}
