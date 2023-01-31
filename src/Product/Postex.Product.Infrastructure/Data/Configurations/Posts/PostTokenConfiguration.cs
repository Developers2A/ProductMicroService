﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Posts;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations.Posts
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