using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations.ValueAddedPrices
{
    public class ValueAddedTypeConfiguration : BaseEntityConfiguration<ValueAddedType>
    {
        public override void Configure(EntityTypeBuilder<ValueAddedType> builder)
        {
            base.Configure(builder);
            builder.ToTable("ValueAddedTypes");

            builder.Property(i => i.Name)
                .HasMaxLength(200);
        }
    }
}