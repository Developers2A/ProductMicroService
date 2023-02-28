using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Posts;

namespace Postex.Product.Infrastructure.Data.Configurations.Posts
{
    public class PostCityShopConfiguration : BaseEntityConfiguration<PostCityShop>
    {
        public override void Configure(EntityTypeBuilder<PostCityShop> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.FullName)
                .HasMaxLength(200);

            builder.Property(i => i.UserName)
                .HasMaxLength(200);

            builder.Property(i => i.CityName)
               .HasMaxLength(200);

            builder.Property(i => i.Code)
               .HasMaxLength(200);

            builder.ToTable("PostCityShops");
        }
    }
}