using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.ValueAddedPrices;

namespace Product.Infrastructure.Data.Configurations.Common
{
    public class PostexCodConfiguration : BaseEntityConfiguration<PostexCod>
    {
        public override void Configure(EntityTypeBuilder<PostexCod> builder)
        {
            base.Configure(builder);
            builder.ToTable("PostexCods");
            builder.Property(i => i.Name)
               .HasMaxLength(200);
        }
    }
}