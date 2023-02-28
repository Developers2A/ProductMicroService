using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;

namespace Postex.Product.Infrastructure.Data.Configurations.Contracts
{
    public class ContractCodConfiguration : BaseEntityConfiguration<ContractCod>
    {
        public override void Configure(EntityTypeBuilder<ContractCod> entity)
        {
            base.Configure(entity);
            entity.ToTable("ContractCods");
            entity.Property(c => c.Description)
                .HasMaxLength(512);
        }
    }
}
