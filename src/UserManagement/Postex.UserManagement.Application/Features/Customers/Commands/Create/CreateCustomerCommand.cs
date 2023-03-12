using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Domain.Customers;

namespace Postex.UserManagement.Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommand : ITransactionRequest<Customer>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string PostalCode { get; set; }

        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
