using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Dtos.Users
{
    public class UserInvoiceInfoDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int AddressId { get; set; }
        public string TelNo { get; set; }
        public string NationalCode { get; set; }
        public string EconomicCode { get; set; }
    }
}
