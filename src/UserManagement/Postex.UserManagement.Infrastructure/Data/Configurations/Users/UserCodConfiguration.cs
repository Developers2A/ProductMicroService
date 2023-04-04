using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Infrastructure.Data.Configurations.Users
{
    public class UserCodConfiguration : BaseEntityConfiguration<UserCod, int>
    {
        public override void Configure(EntityTypeBuilder<UserCod> entity)
        {
            base.Configure(entity);

            entity.ToTable("UserCods");

            entity.Property(c => c.AccountNumber)
                .HasMaxLength(30);

            entity.Property(c => c.AccountSheba)
                .HasMaxLength(30);

            entity.Property(c => c.BankBranchName)
                .HasMaxLength(64);

            entity.Property(c => c.BirthDate)
                .HasMaxLength(10);

            entity.Property(c => c.NationalIDSerial)
                .HasMaxLength(20);
        }
    }
}
