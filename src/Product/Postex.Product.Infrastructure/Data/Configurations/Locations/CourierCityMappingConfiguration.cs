using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Couriers;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations.Locations
{
    public class CourierCityMappingConfiguration : BaseEntityConfiguration<CourierCityMapping>
    {
        public override void Configure(EntityTypeBuilder<CourierCityMapping> builder)
        {
            base.Configure(builder);
            builder.ToTable("CourierCityMappings");

            builder.Property(i => i.MappedCode)
                .HasMaxLength(200);

            builder.HasOne(i => i.City)
                .WithMany(i => i.CourierCityMappings)
                .HasForeignKey(i => i.CityId);

            builder.HasOne(i => i.Courier)
                .WithMany(i => i.CourierCityMappings)
                .HasForeignKey(i => i.CourierId);
        }
    }
}