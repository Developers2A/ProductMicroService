using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations.Common
{
    public class ParcelCitiyConfiguration : BaseEntityConfiguration<CourierCityTypePrice>
    {
        public override void Configure(EntityTypeBuilder<CourierCityTypePrice> builder)
        {
            base.Configure(builder);
            builder.ToTable("CourierCityTypePrices");
        }
    }
}