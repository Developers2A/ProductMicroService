using Postex.Notification.Application.Contracts;
using Postex.Notification.Application.Dtos.Templates;

namespace Postex.Notification.Application.Features.Templates.Queries.GetAll;

public class GetTemplatesQuery : ITransactionRequest<List<TemplateDto>>
{
    public int? TemplateType { get; set; }
}
