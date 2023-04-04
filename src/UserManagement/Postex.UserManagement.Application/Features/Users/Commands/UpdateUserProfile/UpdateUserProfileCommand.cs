using Postex.UserManagement.Application.Contracts;

namespace Postex.UserManagement.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserProfileCommand : ITransactionRequest
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
}
