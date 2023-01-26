using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Contract.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Infrastructure.Data.Configurations
{
    public class ContractAccountingTemplateConfiguration:BaseEntityConfiguration<ContractAccountingTemplate>
    {
        public override void Configure(EntityTypeBuilder<ContractAccountingTemplate> entity)
        {
            base.Configure(entity);
            entity.ToTable("cn_ContractAccountingTemplates");
            entity.Property(c => c.ContractDetailType)
                .HasMaxLength(64);
        }
    }
}
