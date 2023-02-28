using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Posts;

namespace Postex.Product.Infrastructure.Data.Configurations.Posts
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