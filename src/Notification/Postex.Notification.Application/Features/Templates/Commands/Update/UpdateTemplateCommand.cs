using Postex.Notification.Application.Contracts;
using Postex.Notification.Domain.Templates;

namespace Postex.Notification.Application.Features.Templates.Commands.Update
{
    public class UpdateTemplateCommand : ITransactionRequest<Template>
    {
        public int Id { get; set; }
        public string TemplateContent { get; set; }
    }
}
