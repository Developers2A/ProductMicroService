using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierCityTypeConfiguration : IEntityTypeConfiguration<CourierCityType>
    {
        public void Configure(EntityTypeBuilder<CourierCityType> builder)
        {
            builder.ToTable("CourierCityTypes");
        }
    }
}