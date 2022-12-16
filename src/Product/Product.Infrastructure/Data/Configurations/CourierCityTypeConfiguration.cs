using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierCityTypeConfiguration : BaseEntityConfiguration<CourierCityType>
    {
        public override void Configure(EntityTypeBuilder<CourierCityType> builder)
        {
            base.Configure(builder);
            builder.ToTable("CourierCityTypes");

            builder.HasOne(i => i.City)
               .WithMany(i => i.CourierCityTypes)
               .HasForeignKey(i => i.CityId);

            builder.HasOne(i => i.Courier)
                .WithMany(i => i.CourierCityTypes)
                .HasForeignKey(i => i.CourierId);
        }
    }
}