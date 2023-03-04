using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Notification.Domain.Messages;

namespace Postex.Notification.Infrastructure.Data.Configurations.Messages;

public class MessageConfiguration : BaseEntityConfiguration<Message, int>
{
    public override void Configure(EntityTypeBuilder<Message> entity)
    {
        base.Configure(entity);

        entity.ToTable("Messages");

        entity.Property(c => c.MessageContent)
            .HasMaxLength(1000);
    }
}
