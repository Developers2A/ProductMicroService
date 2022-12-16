using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Locations;

namespace Product.Infrastructure.Data.Configurations
{
    public class ZoneConfiguration : BaseEntityConfiguration<Zone>
    {
        public override void Configure(EntityTypeBuilder<Zone> builder)
        {
            base.Configure(builder);
            builder.ToTable("Zones");

            builder.Property(i => i.Name)
                .HasMaxLength(200);
        }
    }
}