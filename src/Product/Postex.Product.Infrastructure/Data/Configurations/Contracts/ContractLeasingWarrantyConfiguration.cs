using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;

namespace Postex.Product.Infrastructure.Data.Configurations.Contracts
{
    public class ContractLeasingWarrantyConfiguration : BaseEntityConfiguration<ContractLeasingWarranty>
    {
        public override void Configure(EntityTypeBuilder<ContractLeasingWarranty> entity)
        {
            base.Configure(entity);
            entity.ToTable("ContractLeasingWarranties");
            entity.Property(c => c.Description)
                .HasMaxLength(512);
        }
    }
}
