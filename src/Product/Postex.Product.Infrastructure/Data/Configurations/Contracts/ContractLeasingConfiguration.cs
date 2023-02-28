using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;

namespace Postex.Product.Infrastructure.Data.Configurations.Contracts
{
    public class ContractLeasingConfiguration : BaseEntityConfiguration<ContractLeasing>
    {
        public override void Configure(EntityTypeBuilder<ContractLeasing> entity)
        {
            base.Configure(entity);
            entity.ToTable("ContractLeasings");
            entity.Property(c => c.Description)
                .HasMaxLength(512);
        }
    }
}
