﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.UserManagement.Domain;

namespace Postex.UserManagement.Infrastructure.Data.Configurations.Common
{
    public class UserRoleConfiguration : BaseEntityConfiguration<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserRoles");

            builder.HasOne(i => i.User)
                .WithMany(i => i.UserRoles)
                .HasForeignKey(i => i.UserId);

            builder.HasOne(i => i.Role)
             .WithMany(i => i.UserRoles)
             .HasForeignKey(i => i.RoleId);
        }
    }
}