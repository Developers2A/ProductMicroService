﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Notification.Domain.Templates;

namespace Postex.Notification.Infrastructure.Data.Configurations.Templates;

public class TemplateConfiguration : BaseEntityConfiguration<Template, int>
{
    public override void Configure(EntityTypeBuilder<Template> builder)
    {
        base.Configure(builder);

        builder.ToTable("Templates");
        builder.Property(i => i.Content)
           .HasMaxLength(1000);

        builder.HasMany(i => i.Parameters)
          .WithOne(i => i.Template)
          .HasForeignKey(i => i.TemplateId);
    }
}