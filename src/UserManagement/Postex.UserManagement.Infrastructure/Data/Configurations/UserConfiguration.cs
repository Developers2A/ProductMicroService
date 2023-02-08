using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.UserManagement.Domain;

namespace Postex.UserManagement.Infrastructure.Data.Configurations.Common
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("Users");
            builder.Property(i => i.UserName)
               .HasMaxLength(20);
            builder.Property(i => i.Mobile)
                .HasMaxLength(20);
            builder.Property(i => i.Password)
              .HasMaxLength(200);
            builder.Property(i => i.Email)
             .HasMaxLength(200);
            builder.HasData(Seed());
        }

        private static object[] Seed()
        {
            var createDate = new DateTime(2022, 12, 12, 12, 12, 0);
            return new object[]
            {
                new User {
                    Id = 1,
                    UserName = "Admin",
                    Password = "123",
                    Mobile = "09394066727",
                    CreatedOn = createDate
                }
            };
        }

    }
}