using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Posts;

namespace Product.Infrastructure.Data.Configurations
{
    public class PostShopConfiguration : BaseEntityConfiguration<PostShop>
    {
        public override void Configure(EntityTypeBuilder<PostShop> builder)
        {
            base.Configure(builder);
            builder.ToTable("PostShops");
        }
    }
}