using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.Create
{
    public class CreateUserCommand : ITransactionRequest<User>
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
