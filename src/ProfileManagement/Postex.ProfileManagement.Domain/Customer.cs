using Postex.SharedKernel.Domain;

namespace Postex.ProfileManagement.Domain
{
    public class Customer :  BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public string PostalCode { get; set; }
        public bool isShahkarValidate { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
