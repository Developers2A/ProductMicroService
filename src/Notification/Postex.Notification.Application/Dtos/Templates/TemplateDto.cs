using Postex.Notification.Domain.Templates;

namespace Postex.Notification.Application.Dtos.Templates
{
    public class TemplateDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public TemplateType TemplateType { get; set; }
        public List<TemplateParameterDto> Parameters { get; set; }
    }
}
