using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Infrastructure.Data.Configurations.Users
{
    public class VerificationCodeConfiguration : BaseEntityConfiguration<VerificationCode, int>
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