using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.ValueAddedPrices;

namespace Product.Infrastructure.Data.Configurations
{
    public class ValueAddedPriceConfiguration : IEntityTypeConfiguration<ValueAddedPrice>
    {
        public void Configure(EntityTypeBuilder<ValueAddedPrice> builder)
        {
            builder.ToTable("ValueAddedPrices");

            builder.Property(i => i.Name)
                .HasMaxLength(200);
        }
    }
}