using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Locations;

namespace Product.Infrastructure.Data.Configurations
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

            builder.HasOne(i => i.State)
               .WithMany(i => i.Cities)
               .HasForeignKey(i => i.StateId);
        }
    }
}