using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Posts;
using Product.Infrastructure.Data.Configurations.Common;

namespace Product.Infrastructure.Data.Configurations.Posts
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