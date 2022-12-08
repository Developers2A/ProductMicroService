using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.ValueAddedPrices;

namespace Product.Infrastructure.Data.Configurations
{
    public class PostexCodConfiguration : IEntityTypeConfiguration<PostexCod>
    {
        public void Configure(EntityTypeBuilder<PostexCod> builder)
        {
            builder.ToTable("PostexCods");
            builder.Property(i => i.Name)
               .HasMaxLength(200);
        }
    }
}