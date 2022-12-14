using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierServiceZoneConfiguration : IEntityTypeConfiguration<CourierServiceZone>
    {
        public void Configure(EntityTypeBuilder<CourierServiceZone> builder)
        {
            builder.ToTable("CourierServiceZones");

            builder.HasOne(i => i.Courier)
               .WithMany(i => i.CourierServiceZones)
               .HasForeignKey(i => i.CourierId);

            builder.HasOne(i => i.StateFrom)
               .WithMany(i => i.StateFromCourierServiceZones)
               .HasForeignKey(i => i.StateFromId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.StateTo)
              .WithMany(i => i.StateToCourierServiceZones)
              .HasForeignKey(i => i.StateToId)
              .OnDelete(DeleteBehavior.NoAction); ;

            builder.HasOne(i => i.Zone)
               .WithMany(i => i.CourierServiceZones)
               .HasForeignKey(i => i.ZoneId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.CourierService)
               .WithMany(i => i.CourierServiceZones)
               .HasForeignKey(i => i.CourierServiceId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}