using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations
{
    public class ContractAccountingTemplateConfiguration : BaseEntityConfiguration<ContractAccountingTemplate>
    {
        public override void Configure(EntityTypeBuilder<ContractAccountingTemplate> entity)
        {
            base.Configure(entity);
            entity.ToTable("ContractAccountingTemplates");
            entity.Property(c => c.ContractDetailType)
                .HasMaxLength(64);
        }
    }
}
