using Postex.Notification.Domain.Templates;

namespace Postex.Notification.Application.Dtos.Templates
{
    public class TemplateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Content { get; set; }

        //IsCustom = false : این الگو از الگوهای سامانه پیامکی می باشد
        //IsCustom = true : این الگو از الگوهای سیستم پستکس  می باشد
        public bool IsCustom { get; set; }

        public TemplateType TemplateType { get; set; }
        public List<TemplateParameterDto> Parameters { get; set; }
    }
}
