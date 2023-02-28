using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;

namespace Postex.Product.Infrastructure.Data.Configurations.Contracts
{
    public class ContractInfoConfiguration : BaseEntityConfiguration<ContractInfo>
    {
        public override void Configure(EntityTypeBuilder<ContractInfo> entity)
        {
            base.Configure(entity);
            entity.ToTable("ContractInfos");
            entity.Property(c => c.ContractNo)
                .HasMaxLength(64);
            entity.Property(c => c.Title)
                .HasMaxLength(128);
            entity.Property(c => c.Description)
                .HasMaxLength(512);

        }
    }
}
