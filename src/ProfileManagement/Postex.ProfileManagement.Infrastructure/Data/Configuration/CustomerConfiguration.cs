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
    public class CustomerConfiguration : BaseEntityConfiguration<Customer,Guid>
    {
        public override void Configure(EntityTypeBuilder<Customer> entity)
        {
            base.Configure(entity);
            entity.ToTable("Customer");
            //entity.HasKey(c => c.Id);
            //entity.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //entity.Property(c => c.Id).IsRequired();


            entity.Property(c => c.FirstName)
                .HasMaxLength(64);
            entity.Property(c => c.LastName)
                   .HasMaxLength(64);
            entity.Property(c => c.FatherName)
                .HasMaxLength(64);
            entity.Property(c => c.Email)
              .HasMaxLength(128);
            entity.Property(c => c.NationalCode)
             .HasMaxLength(10);
            entity.Property(c => c.PostalCode)
           .HasMaxLength(10);
        }
    }
}
