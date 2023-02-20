using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations
{
    public class ContractCodConfiguration : BaseEntityConfiguration<ContractCod>
    {
        public override void Configure(EntityTypeBuilder<ContractCod> entity)
        {
            base.Configure(entity);
            entity.ToTable("cn_ContractCods");
            entity.Property(c => c.Description)
                .HasMaxLength(512);
        }
    }
}
