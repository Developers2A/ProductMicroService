using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations
{
    public class ContractCollect_DistributeConfiguration : BaseEntityConfiguration<ContractCollect_Distribute>
    {
        public override void Configure(EntityTypeBuilder<ContractCollect_Distribute> entity)
        {
            base.Configure(entity);
            entity.ToTable("cn_ContractCollect_Distributes");
            entity.Property(c => c.Description)
                .HasMaxLength(512);
        }
    }
}
