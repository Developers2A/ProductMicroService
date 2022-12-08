using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Locations;

namespace Product.Infrastructure.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");

            builder.Property(i => i.Name)
                .HasMaxLength(200);

            builder.Property(i => i.EnglishName)
                .HasMaxLength(200);

            builder.HasOne(i => i.State)
               .WithMany(i => i.Cities)
               .HasForeignKey(i => i.StateId);
        }
    }
}