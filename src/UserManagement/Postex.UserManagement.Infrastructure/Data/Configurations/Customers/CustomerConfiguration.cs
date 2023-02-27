using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.UserManagement.Domain.Customers;

namespace Postex.UserManagement.Infrastructure.Data.Configurations.Customers
{
    public class CustomerConfiguration : BaseEntityConfiguration<Customer, int>
    {
        public override void Configure(EntityTypeBuilder<Customer> entity)
        {
            base.Configure(entity);
            entity.ToTable("Customers");
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
