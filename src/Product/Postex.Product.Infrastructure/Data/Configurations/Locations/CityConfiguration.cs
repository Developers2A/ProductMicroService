using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Locations;

namespace Postex.Product.Infrastructure.Data.Configurations.Locations
{
    public class CityConfiguration : BaseEntityConfiguration<City>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            base.Configure(builder);
            builder.ToTable("Cities");

            builder.Property(i => i.Name)
                .HasMaxLength(200);

            builder.Property(i => i.EnglishName)
                .HasMaxLength(200);

            builder.Property(i => i.RowVersion)
                .IsRowVersion();

            builder.HasOne(i => i.Province)
               .WithMany(i => i.Cities)
               .HasForeignKey(i => i.ProvinceId);
        }
    }
}