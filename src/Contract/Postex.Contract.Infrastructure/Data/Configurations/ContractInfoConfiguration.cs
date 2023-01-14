using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Contract.Domain;

namespace Postex.Contract.Infrastructure.Data.Configurations
{
    public class ContractInfoConfiguration:BaseEntityConfiguration<ContractInfo>
    {
        public override void Configure(EntityTypeBuilder<ContractInfo> entity)
        {
            base.Configure(entity);
            entity.ToTable("cn_ContractsInfo");
            entity.Property(c => c.ContractNo)
                .HasMaxLength(64);
            entity.Property(c => c.Title)
                .HasMaxLength(128);
            entity.Property(c => c.Description)
                .HasMaxLength(512);

        }
    }
}
