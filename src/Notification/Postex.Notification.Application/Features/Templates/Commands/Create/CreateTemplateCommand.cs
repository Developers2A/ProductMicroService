using Postex.Notification.Application.Contracts;
using Postex.Notification.Domain.Templates;

namespace Postex.Notification.Application.Features.Templates.Commands.Create
{
    public class CreateTemplateCommand : ITransactionRequest<Template>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public string PostalCode { get; set; }

        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
