using Postex.SharedKernel.Domain;

namespace Postex.UserManagement.Domain.Users;

public class Role : BaseEntity<int>
{
    public string Name { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}
