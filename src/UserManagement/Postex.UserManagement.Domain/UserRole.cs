using Postex.SharedKernel.Domain;

namespace Postex.UserManagement.Domain
{
    public class UserRole : BaseEntity<int>
    {
        public User User { get; set; }
        public Guid UserId { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}
