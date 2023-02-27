using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Infrastructure.Data.Configurations.Users
{
    public class UserConfiguration : BaseEntityConfiguration<User, Guid>
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
            builder.Property(i => i.FirstName)
                .HasMaxLength(200);
            builder.Property(i => i.LastName)
                .HasMaxLength(200);
            builder.Property(i => i.Email)
             .HasMaxLength(200);
            builder.Property(i => i.NationalCode)
             .HasMaxLength(10);
            builder.HasData(Seed());
        }

        private static object[] Seed()
        {
            var createDate = new DateTime(2022, 12, 12, 12, 12, 0);
            return new object[]
            {
                new User {
                    Id = Guid.NewGuid(),
                    UserName = "Admin",
                    FirstName = "ادمین",
                    LastName = "سیستم",
                    Password = "123",
                    Mobile = "09394066727",
                    CreatedOn = createDate
                }
            };
        }

    }
}