using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Offlines;
using Product.Infrastructure.Data.Configurations.Common;

namespace Product.Infrastructure.Data.Configurations.Offlines
{
    public class CourierZoneConfiguration : BaseEntityConfiguration<CourierZone>
    {
        public override void Configure(EntityTypeBuilder<CourierZone> builder)
        {
            base.Configure(builder);
            builder.ToTable("CourierZones");

            builder.HasOne(i => i.Courier)
                .WithMany(i => i.CourierZones)
                .HasForeignKey(i => i.CourierId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}