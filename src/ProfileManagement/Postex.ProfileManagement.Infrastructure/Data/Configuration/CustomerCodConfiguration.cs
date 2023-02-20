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
    public class CustomerCodConfiguration:BaseEntityConfiguration<CustomerCod,int>
    {
        public override void Configure(EntityTypeBuilder<CustomerCod> entity)
        {
            base.Configure(entity);

            entity.ToTable("CustomerCod");

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
