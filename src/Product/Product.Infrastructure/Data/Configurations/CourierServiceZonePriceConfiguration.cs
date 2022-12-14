using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierServiceZonePriceConfiguration : IEntityTypeConfiguration<CourierServiceZonePrice>
    {
        public void Configure(EntityTypeBuilder<CourierServiceZonePrice> builder)
        {
            builder.ToTable("CourierServiceZonePrices");
        }
    }
}