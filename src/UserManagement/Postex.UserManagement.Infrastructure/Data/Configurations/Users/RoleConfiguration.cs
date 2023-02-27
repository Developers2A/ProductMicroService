using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Infrastructure.Data.Configurations.Users
{
    public class RoleConfiguration : BaseEntityConfiguration<Role, int>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);

            builder.ToTable("Roles");
            builder.Property(i => i.Name)
               .HasMaxLength(100);
        }

        private static object[] Seed()
        {
            var createDate = new DateTime(2022, 12, 12, 12, 12, 0);
            return new object[]
            {
                new Role {
                    Id = 1,
                    Name = "Admin",
                    CreatedOn = createDate
                },
                new Role {
                    Id = 2,
                    Name = "User",
                    CreatedOn = createDate
                }
            };
        }

    }
}