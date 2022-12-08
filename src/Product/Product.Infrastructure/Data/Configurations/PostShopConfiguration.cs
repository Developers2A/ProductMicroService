using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Posts;

namespace Product.Infrastructure.Data.Configurations
{
    public class PostShopConfiguration : IEntityTypeConfiguration<PostShop>
    {
        public void Configure(EntityTypeBuilder<PostShop> builder)
        {
            builder.ToTable("PostShops");
        }
    }
}