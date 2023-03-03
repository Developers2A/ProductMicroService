namespace Postex.Notification.Domain.Templates
{
    public class TemplateParameter
    {
        public string TemlateContent { get; set; }
        public string Parameter { get; set; }

        public override string ToString()
        {
            return string.Format(TemlateContent, Parameter);
        }
    }
}
