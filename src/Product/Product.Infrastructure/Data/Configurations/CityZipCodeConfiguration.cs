﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceProvider.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CityZipCodeConfiguration : IEntityTypeConfiguration<CityZipCode>
    {
        public void Configure(EntityTypeBuilder<CityZipCode> builder)
        {
            builder.ToTable("CityZipCodes");
            builder.Property(i => i.ZipCode)
               .HasMaxLength(200);
            builder.Property(i => i.ParcelCode)
              .HasMaxLength(200);

            builder.HasOne(i => i.City)
               .WithMany(i => i.CityZipCodes)
               .HasForeignKey(i => i.CityId);
        }
    }
}