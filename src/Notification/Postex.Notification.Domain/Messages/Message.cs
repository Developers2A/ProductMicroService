using Postex.Notification.Domain.Templates;
using Postex.SharedKernel.Domain;

namespace Postex.Notification.Domain.Messages
{
    public class Message : BaseEntity<int>
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public string MessageContent { get; private set; }
        public long? ServerId { get; private set; }
        public MessageType MessageType { get; private set; }
        public MessageStatus MessageStatus { get; private set; }
        public DateTime SendDate { get; private set; }

        public int? TemplateId { get; set; }
        public Template Template { get; set; }

        public long MessageId { get; set; }

        public Message()
        {
        }

        public Message(string from, string to, string messageContent, MessageType messageType, DateTime sendDate, int? templateId)
        {
            GuardAgainstEmptyProperty(from, From, "مبدا وارد نشده است");
            GuardAgainstEmptyProperty(to, To, "مقصد وارد نشده است");
            GuardAgainstEmptyProperty(messageContent, To, "متن پیام وارد نشده است");
            GuradAgainstInvalidDateTime(sendDate);

            From = from;
            To = to;
            MessageContent = messageContent;
            MessageType = messageType;
            MessageStatus = MessageStatus.Queued;
            SendDate = sendDate;
            TemplateId = templateId;
        }
        public void SetMessageId(long messageId)
        {
            MessageId = messageId;
        }
        public void SetStatus(MessageStatus messageStatus)
        {
            MessageStatus = messageStatus;
        }
        private void GuardAgainstEmptyProperty(string property, string paramName, string message)
        {
            if (string.IsNullOrWhiteSpace(property))
                throw new ArgumentNullException(paramName, message);
        }

        private void GuradAgainstInvalidDateTime(DateTime sendDate)
        {
            if (sendDate == default)
                throw new Exception("تاریخ نامعتبر میباشد");
        }

        private void GuradAgainstInvalidMessageStautRange(MessageStatus messageStatus)
        {
            if (!Enum.IsDefined(typeof(MessageStatus), messageStatus))
                throw new Exception("وضعیت پیام نا معتبر است");
        }

        private void GradAgainstInvalidMessageTypeRange(MessageType messageType)
        {
            if (!Enum.IsDefined(typeof(MessageType), messageType))
                throw new Exception("نوع پیام نا معتبر است");
        }
    }
}
