using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.ProfileManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.ProfileManagement.Infrastructure.Data.Configuration
{
    public class CustomerInvoiceInfoConfiguration:BaseEntityConfiguration<CustomerInvoiceInfo>
    {
        public override void Configure(EntityTypeBuilder<CustomerInvoiceInfo> entity)
        {
            base.Configure(entity);

            entity.ToTable("CustomerInvoiceInfo");

            entity.Property(c => c.EconomicCode)
                .HasMaxLength(30);
            entity.Property(c => c.NationalCode)
                .HasMaxLength(30);
            entity.Property(c => c.TelNo)
                .HasMaxLength(30);



        }
    }
}
