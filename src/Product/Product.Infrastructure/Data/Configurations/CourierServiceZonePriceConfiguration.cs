using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierServiceZonePriceConfiguration : BaseEntityConfiguration<CourierServiceZonePrice>
    {
        public override void Configure(EntityTypeBuilder<CourierServiceZonePrice> builder)
        {
            base.Configure(builder);
            builder.ToTable("CourierServiceZonePrices");
        }
    }
}