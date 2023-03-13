using Postex.SharedKernel.Domain;

namespace Postex.Notification.Domain.Templates;

public class Template : BaseEntity<int>
{
    public string Name { get; set; }
    public string? Content { get; set; }
    public TemplateType TemplateType { get; set; }
    public ICollection<TemplateParameter> Parameters { get; set; }
}
