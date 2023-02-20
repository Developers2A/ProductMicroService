using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations
{
    public class ContractLeasingConfiguration : BaseEntityConfiguration<ContractLeasing>
    {
        public override void Configure(EntityTypeBuilder<ContractLeasing> entity)
        {
            base.Configure(entity);
            entity.ToTable("cn_ContractLeasings");
            entity.Property(c => c.Description)
                .HasMaxLength(512);
        }
    }
}
