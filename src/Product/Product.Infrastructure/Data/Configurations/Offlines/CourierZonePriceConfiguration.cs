﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Offlines;
using Product.Infrastructure.Data.Configurations.Common;

namespace Product.Infrastructure.Data.Configurations.Offlines
{
    public class CourierZonePriceConfiguration : BaseEntityConfiguration<CourierZonePrice>
    {
        public override void Configure(EntityTypeBuilder<CourierZonePrice> builder)
        {
            base.Configure(builder);
            builder.ToTable("CourierZonePrices");

            builder.HasOne(i => i.FromCourierZone)
               .WithMany(i => i.FromCourierZonePrices)
               .HasForeignKey(i => i.FromCourierZoneId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.ToCourierZone)
              .WithMany(i => i.ToCourierZonePrices)
              .HasForeignKey(i => i.ToCourierZoneId)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }
}