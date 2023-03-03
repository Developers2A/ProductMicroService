using Postex.SharedKernel.Domain;

namespace Postex.Notification.Domain.Templates
{
    public class Template : BaseEntity<int>
    {
        public string TemplateContent { get; set; }

        public TemplateType TemplateType { get; set; }

        public Template(string templateContent, TemplateType templateType)
        {
            //GuardAgainstEmptyProperty(templateContent, TemplateContent, "محتوای قالب وارد نشده است");

            TemplateContent = templateContent;
            TemplateType = templateType;
        }
        public void SetTemplate(string templateContent, TemplateType templateType)
        {
            TemplateContent = templateContent;
            TemplateType = templateType;
        }
    }
}
