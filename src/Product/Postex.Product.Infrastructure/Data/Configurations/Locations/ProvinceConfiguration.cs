using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Locations;

namespace Postex.Product.Infrastructure.Data.Configurations.Locations
{
    public class ProvinceConfiguration : BaseEntityConfiguration<Province>
    {
        public override void Configure(EntityTypeBuilder<Province> builder)
        {
            base.Configure(builder);

            builder.ToTable("States");

            builder.Property(i => i.Name)
                .HasMaxLength(200);

            builder.Property(i => i.EnglishName)
                .HasMaxLength(200);
        }
    }
}