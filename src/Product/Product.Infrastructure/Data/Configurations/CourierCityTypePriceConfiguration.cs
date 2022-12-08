using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class ParcelCitiyConfiguration : IEntityTypeConfiguration<CourierCityTypePrice>
    {
        public void Configure(EntityTypeBuilder<CourierCityTypePrice> builder)
        {
            builder.ToTable("CourierCityTypePrices");
        }
    }
}