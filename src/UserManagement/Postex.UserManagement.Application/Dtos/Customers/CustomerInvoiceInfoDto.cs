using Postex.UserManagement.Domain.Customers;

namespace Postex.UserManagement.Application.Dtos.Customers
{
    public class CustomerInvoiceInfoDto
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AddressId { get; set; }
        public int TelNo { get; set; }
        public string NationalCode { get; set; }
        public string EconomicCode { get; set; }
    }
}
