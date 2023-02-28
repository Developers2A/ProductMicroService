using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;

namespace Postex.Product.Infrastructure.Data.Configurations.Contracts
{
    public class ContractInsuranceConfiguration : BaseEntityConfiguration<ContractInsurance>
    {
        public override void Configure(EntityTypeBuilder<ContractInsurance> entity)
        {
            base.Configure(entity);
            entity.ToTable("ContractInsurances");
            entity.Property(c => c.Description)
                .HasMaxLength(512);


        }
    }
}
