﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Offlines;
using Product.Infrastructure.Data.Configurations.Common;

namespace Product.Infrastructure.Data.Configurations.Offlines
{
    public class CourierZonePriceTemplateConfiguration : BaseEntityConfiguration<CourierZonePriceTemplate>
    {
        public override void Configure(EntityTypeBuilder<CourierZonePriceTemplate> builder)
        {
            base.Configure(builder);
            builder.ToTable("CourierZonePriceTemplates");

            builder.HasOne(i => i.CourierService)
               .WithMany(i => i.CourierZonePriceTemplates)
               .HasForeignKey(i => i.CourierServiceId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}