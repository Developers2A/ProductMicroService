using Postex.SharedKernel.Domain;

namespace Postex.Notification.Domain.Templates;

public class Template : BaseEntity<int>
{
    public string Name { get; set; }
    public string? Content { get; set; }
    public TemplateType TemplateType { get; set; }

    //true : این الگو جدید است و فقط در سامانه پستکس تعریف شده است
    //false : این الگو از قبل در سامانه پیامکی نیز تعریف شده است
    public bool IsCustom { get; set; }

    public ICollection<TemplateParameter> Parameters { get; set; }
}
