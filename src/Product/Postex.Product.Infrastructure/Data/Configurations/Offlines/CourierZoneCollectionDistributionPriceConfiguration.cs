﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.CollectionDistributionPrices;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations.Offlines
{
    public class CourierZoneCollectionDistributionPriceConfiguration : BaseEntityConfiguration<CourierZoneCollectionDistributionPrice>
    {
        public override void Configure(EntityTypeBuilder<CourierZoneCollectionDistributionPrice> builder)
        {
            base.Configure(builder);
            builder.ToTable("CourierZoneCollectionDistributionPrices");
        }
    }
}