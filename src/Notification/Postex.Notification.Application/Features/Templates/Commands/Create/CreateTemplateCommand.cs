using Postex.Notification.Application.Contracts;
using Postex.Notification.Application.Dtos.Templates;
using Postex.Notification.Domain.Templates;

namespace Postex.Notification.Application.Features.Templates.Commands.Create;

public class CreateTemplateCommand : ITransactionRequest<TemplateDto>
{
    public string Name { get; set; }
    public string? Content { get; set; }
    public TemplateType TemplateType { get; set; }
    public bool IsCustom { get; set; }
    public List<TemplateParameterDto>? Parameters { get; set; }
}
