using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.ValueAddedPrices;

namespace Postex.Product.Infrastructure.Data.Configurations.Common
{
    public class ValueAddedPriceConfiguration : BaseEntityConfiguration<ValueAddedPrice>
    {
        public override void Configure(EntityTypeBuilder<ValueAddedPrice> builder)
        {
            base.Configure(builder);
            builder.ToTable("ValueAddedPrices");

            builder.Property(i => i.Name)
                .HasMaxLength(200);
        }
    }
}