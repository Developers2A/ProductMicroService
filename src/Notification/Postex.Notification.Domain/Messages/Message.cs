using Postex.Notification.Domain.Templates;
using Postex.SharedKernel.Domain;

namespace Postex.Notification.Domain.Messages
{
    public class Message : BaseEntity<int>
    {
        public string Sender { get; set; }
        public string Receptor { get; set; }
        public string MessageContent { get; set; }
        public MessageType MessageType { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public DateTime SendDate { get; set; }
        public int? TemplateId { get; set; }
        public Template Template { get; set; }
    }
}
