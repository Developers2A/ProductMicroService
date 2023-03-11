using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Notification.Domain.Messages;

namespace Postex.Notification.Infrastructure.Data.Configurations.Templates;

public class MessageConfiguration : BaseEntityConfiguration<Message, int>
{
    public override void Configure(EntityTypeBuilder<Message> builder)
    {
        base.Configure(builder);

        builder.ToTable("Messages");
    }
}