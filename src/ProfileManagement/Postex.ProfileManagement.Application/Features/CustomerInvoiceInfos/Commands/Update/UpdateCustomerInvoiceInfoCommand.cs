using Postex.ProfileManagement.Application.Contracts;
using Postex.ProfileManagement.Domain;

namespace Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Commands.Update
{
    public class UpdateCustomerInvoiceInfoCommand : ITransactionRequest<CustomerInvoiceInfo>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }       
        public int AddressId { get; set; }
        public int TelNo { get; set; }
        public string NationalCode { get; set; }
        public string EconomicCode { get; set; }
    }
}
