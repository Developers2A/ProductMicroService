using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations
{
    public class ContractBoxPriceConfiguration : BaseEntityConfiguration<ContractBoxPrice>
    {
        public override void Configure(EntityTypeBuilder<ContractBoxPrice> entity)
        {
            base.Configure(entity);
            entity.ToTable("ContractBoxPrices");
            entity.Property(c => c.Description)
                .HasMaxLength(512);
        }
    }
}
