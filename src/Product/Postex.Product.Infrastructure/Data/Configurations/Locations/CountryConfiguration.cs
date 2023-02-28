using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Locations;

namespace Postex.Product.Infrastructure.Data.Configurations.Locations
{
    public class CountryConfiguration : BaseEntityConfiguration<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);

            builder.ToTable("Countries");

            builder.Property(i => i.Name)
                .HasMaxLength(200);

            builder.Property(i => i.Code)
                .HasMaxLength(200);
        }
    }
}