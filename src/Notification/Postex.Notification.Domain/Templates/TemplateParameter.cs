using Postex.SharedKernel.Domain;

namespace Postex.Notification.Domain.Templates;

public class TemplateParameter : BaseEntity<int>
{
    public int TemplateId { get; set; }
    public Template Template { get; set; }
    public string Key { get; set; }
}
