using Postex.SharedKernel.Domain;

namespace Postex.ProfileManagement.Domain
{
    public class CustomerInvoiceInfo : BaseEntity<int>
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AddressId { get; set; }
        public int TelNo { get; set; }
        public string NationalCode { get; set; }
        public string EconomicCode { get; set; }
       
    }
}
