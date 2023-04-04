using Postex.SharedKernel.Domain;

namespace Postex.UserManagement.Domain.Users
{
    public class UserInvoiceInfo : BaseEntity<int>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int AddressId { get; set; }
        public string Phone { get; set; }
        public string NationalCode { get; set; }
        public string EconomicCode { get; set; }
    }
}
