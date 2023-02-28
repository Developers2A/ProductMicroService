using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Offlines;

namespace Postex.Product.Infrastructure.Data.Configurations.Offlines
{
    public class CourierZoneCityMappingConfiguration : BaseEntityConfiguration<CourierZoneCityMapping>
    {
        public override void Configure(EntityTypeBuilder<CourierZoneCityMapping> builder)
        {
            base.Configure(builder);
            builder.ToTable("CourierZoneCityMappings");

            //builder.HasOne(i => i.Courier)
            // .WithMany(i => i.CourierServiceZones)
            // .HasForeignKey(i => i.CourierId);

            builder.HasOne(i => i.CourierZone)
               .WithMany(i => i.CourierZoneCityMappings)
               .HasForeignKey(i => i.CourierZoneId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.City)
              .WithMany(i => i.CourierZoneCityMappings)
              .HasForeignKey(i => i.CityId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}