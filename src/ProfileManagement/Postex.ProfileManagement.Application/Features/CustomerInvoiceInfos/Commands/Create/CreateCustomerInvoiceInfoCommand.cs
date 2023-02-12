using Postex.ProfileManagement.Application.Contracts;
using Postex.ProfileManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Commands.Create
{
    public class CreateCustomerInvoiceInfoCommand : ITransactionRequest<CustomerInvoiceInfo>
    {
        public int CustomerId { get; set; }      
        public int AddressId { get; set; }
        public int TelNo { get; set; }
        public string NationalCode { get; set; }
        public string EconomicCode { get; set; }
    }
}
