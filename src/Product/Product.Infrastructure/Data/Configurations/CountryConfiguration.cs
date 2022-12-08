using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Locations;

namespace Product.Infrastructure.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.Property(i => i.Name)
                .HasMaxLength(200);

            builder.Property(i => i.Code)
                .HasMaxLength(200);
        }
    }
}