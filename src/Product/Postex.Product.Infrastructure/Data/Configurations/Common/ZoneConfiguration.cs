using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Locations;

namespace Postex.Product.Infrastructure.Data.Configurations.Common
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