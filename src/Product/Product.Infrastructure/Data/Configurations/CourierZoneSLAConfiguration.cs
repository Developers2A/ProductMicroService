using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierZoneSLAConfiguration : IEntityTypeConfiguration<CourierZoneSLA>
    {
        public void Configure(EntityTypeBuilder<CourierZoneSLA> builder)
        {
            builder.ToTable("CourierZoneSLAs");

            builder.HasOne(i => i.Courier)
               .WithMany(i => i.CourierZoneSLAs)
               .HasForeignKey(i => i.CourierId);

            builder.HasOne(i => i.StateFrom)
               .WithMany(i => i.StateFromCourierZoneSLAs)
               .HasForeignKey(i => i.StateFromId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.StateTo)
              .WithMany(i => i.StateToCourierZoneSLAs)
              .HasForeignKey(i => i.StateToId)
              .OnDelete(DeleteBehavior.NoAction); ;

            builder.HasOne(i => i.Zone)
               .WithMany(i => i.CourierZoneSLAs)
               .HasForeignKey(i => i.ZoneId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.SLA)
               .WithMany(i => i.CourierZoneSLAs)
               .HasForeignKey(i => i.SLAId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}