using Postex.ProfileManagement.Application.Contracts;
using Postex.ProfileManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.ProfileManagement.Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommand : ITransactionRequest<Customer>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public string PostalCode { get; set; }

        public int UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
