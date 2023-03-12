using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Notification.Domain.Templates;

namespace Postex.Notification.Infrastructure.Data.Configurations.Templates;

public class TemplateParameterConfiguration : BaseEntityConfiguration<TemplateParameter, int>
{
    public override void Configure(EntityTypeBuilder<TemplateParameter> builder)
    {
        base.Configure(builder);

        builder.ToTable("TemplateParameters");
        builder.Property(i => i.Key)
           .HasMaxLength(64);
        builder.Property(i => i.Key)
          .HasMaxLength(64);
    }
}