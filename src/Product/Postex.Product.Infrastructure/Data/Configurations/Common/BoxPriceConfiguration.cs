using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.ValueAddedPrices;

namespace Postex.Product.Infrastructure.Data.Configurations.Common
{
    public class BoxPriceConfiguration : BaseEntityConfiguration<BoxSizePrice>
    {
        public override void Configure(EntityTypeBuilder<BoxSizePrice> builder)
        {
            base.Configure(builder);

            builder.ToTable("BoxPrices");
        }
    }
}