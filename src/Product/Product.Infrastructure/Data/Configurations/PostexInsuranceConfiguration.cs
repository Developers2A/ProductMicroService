using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.ValueAddedPrices;

namespace Product.Infrastructure.Data.Configurations
{
    public class PostexInsuranceConfiguration : IEntityTypeConfiguration<PostexInsurance>
    {
        public void Configure(EntityTypeBuilder<PostexInsurance> builder)
        {
            builder.ToTable("PostexInsurances");
            builder.Property(i => i.Name)
               .HasMaxLength(200);
        }
    }
}