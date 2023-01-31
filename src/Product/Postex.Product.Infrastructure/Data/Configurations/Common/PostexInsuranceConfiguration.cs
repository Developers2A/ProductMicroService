using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.ValueAddedPrices;

namespace Postex.Product.Infrastructure.Data.Configurations.Common
{
    public class PostexInsuranceConfiguration : BaseEntityConfiguration<PostexInsurance>
    {
        public override void Configure(EntityTypeBuilder<PostexInsurance> builder)
        {
            base.Configure(builder);
            builder.ToTable("PostexInsurances");
            builder.Property(i => i.Name)
               .HasMaxLength(200);
        }
    }
}