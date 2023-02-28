using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;

namespace Postex.Product.Infrastructure.Data.Configurations.Contracts
{
    public class ContractCollectDistributeConfiguration : BaseEntityConfiguration<ContractCollectionDistribution>
    {
        public override void Configure(EntityTypeBuilder<ContractCollectionDistribution> entity)
        {
            base.Configure(entity);
            entity.ToTable("ContractCollectionDistributions");
            entity.Property(c => c.Description)
                .HasMaxLength(512);
        }
    }
}
