using Postex.SharedKernel.Domain;

namespace Postex.Notification.Domain.Templates
{
    public class TemplateParameter : BaseEntity<int>
    {
        public int TemplateId { get; set; }
        public Template Template { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format(Key, Value);
        }
    }
}
