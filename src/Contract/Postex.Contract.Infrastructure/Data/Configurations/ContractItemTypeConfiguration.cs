using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Contract.Domain;

namespace Postex.Contract.Infrastructure.Data.Configurations
{
    public class ContractItemTypeConfiguration : BaseEntityConfiguration<ContractItemType>
    {
        public override void Configure(EntityTypeBuilder<ContractItemType> entity)
        {
            base.Configure(entity);
            entity.ToTable("cn_ContractItemTypes");
            entity.Property(c => c.ContractTypeName)
                .HasMaxLength(128);
            entity.Property(c => c.ContractTypeCode)
                .HasMaxLength(10);

        }
    }
}
