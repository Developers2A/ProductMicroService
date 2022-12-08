using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierZoneSLAPricesConfiguration : IEntityTypeConfiguration<CourierZoneSLAPrice>
    {
        public void Configure(EntityTypeBuilder<CourierZoneSLAPrice> builder)
        {
            builder.ToTable("CourierZoneSLAPrices");
        }
    }
}