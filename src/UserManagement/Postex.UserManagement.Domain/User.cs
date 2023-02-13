using Postex.SharedKernel.Domain;

namespace Postex.UserManagement.Domain
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string IbanNumber { get; set; }
        public string Mobile { get; set; }
        public int DefaultAddressId { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
