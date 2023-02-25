using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Domain.Customers;

namespace Postex.UserManagement.Application.Features.CustomerInvoiceInfos.Commands.Update
{
    public class UpdateCustomerInvoiceInfoCommand : ITransactionRequest<CustomerInvoiceInfo>
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public int AddressId { get; set; }
        public int TelNo { get; set; }
        public string NationalCode { get; set; }
        public string EconomicCode { get; set; }
    }
}
