using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations.ValueAddedPrices
{
    public class ValueAddedPriceConfiguration : BaseEntityConfiguration<ValueAddedPrice>
    {
        public override void Configure(EntityTypeBuilder<ValueAddedPrice> builder)
        {
            base.Configure(builder);
            builder.ToTable("ValueAddedPrices");

            builder.HasOne(i => i.ValueAddedType)
             .WithMany(i => i.ValueAddedPrices)
             .HasForeignKey(i => i.ValueAddedTypeId);
        }
    }
}