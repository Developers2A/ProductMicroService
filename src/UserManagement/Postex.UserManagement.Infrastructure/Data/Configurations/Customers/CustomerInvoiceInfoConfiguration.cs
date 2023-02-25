using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.UserManagement.Domain.Customers;
using Postex.UserManagement.Infrastructure.Data.Configurations.Common;

namespace Postex.UserManagement.Infrastructure.Data.Configuration
{
    public class CustomerInvoiceInfoConfiguration : BaseEntityConfiguration<CustomerInvoiceInfo, int>
    {
        public override void Configure(EntityTypeBuilder<CustomerInvoiceInfo> entity)
        {
            base.Configure(entity);

            entity.ToTable("CustomerInvoiceInfos");

            entity.Property(c => c.EconomicCode)
                .HasMaxLength(30);

            entity.Property(c => c.NationalCode)
                .HasMaxLength(30);

            entity.Property(c => c.TelNo)
                .HasMaxLength(30);
        }
    }
}
