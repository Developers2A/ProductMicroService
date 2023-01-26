using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.CollectionDistributionPrices;
using Product.Infrastructure.Data.Configurations.Common;

namespace Product.Infrastructure.Data.Configurations.Offlines
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