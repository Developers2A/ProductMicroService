using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations
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
