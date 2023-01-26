using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Posts;
using Product.Infrastructure.Data.Configurations.Common;

namespace Product.Infrastructure.Data.Configurations.Posts
{
    public class PostTokenConfiguration : BaseEntityConfiguration<PostToken>
    {
        public override void Configure(EntityTypeBuilder<PostToken> builder)
        {
            base.Configure(builder);
            builder.ToTable("PostTokens");
        }
    }
}