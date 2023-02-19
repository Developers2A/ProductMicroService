using Postex.ProfileManagement.Application.Contracts;
using Postex.ProfileManagement.Domain;

namespace Postex.ProfileManagement.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommand : ITransactionRequest<Customer>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public string PostalCode { get; set; }
        public bool IsShahkarValidate { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
