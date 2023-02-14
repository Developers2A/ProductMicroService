﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.UserManagement.Domain;

namespace Postex.UserManagement.Infrastructure.Data.Configurations.Common
{
    public class VerificationCodeConfiguration : BaseEntityConfiguration<VerificationCode>
    {
        public override void Configure(EntityTypeBuilder<VerificationCode> builder)
        {
            base.Configure(builder);

            builder.ToTable("VerificationCodes");
            builder.Property(i => i.Mobile)
                .HasMaxLength(20);
        }
    }
}