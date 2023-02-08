using Postex.SharedKernel.Domain;

namespace Postex.UserManagement.Domain
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
