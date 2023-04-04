using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Infrastructure.Data.Configurations.Users
{
    public class UserInvoiceInfoConfiguration : BaseEntityConfiguration<UserInvoiceInfo, int>
    {
        public override void Configure(EntityTypeBuilder<UserInvoiceInfo> entity)
        {
            base.Configure(entity);

            entity.ToTable("UserInvoiceInfos");

            entity.Property(c => c.EconomicCode)
                .HasMaxLength(30);

            entity.Property(c => c.NationalCode)
                .HasMaxLength(30);

            entity.Property(c => c.Phone)
                .HasMaxLength(30);
        }
    }
}
