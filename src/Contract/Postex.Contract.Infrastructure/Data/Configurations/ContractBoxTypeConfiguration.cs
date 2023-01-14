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
    public class ContractBoxTypeConfiguration:BaseEntityConfiguration<ContractBoxType>
    {
        public override void Configure(EntityTypeBuilder<ContractBoxType> entity)
        {
            base.Configure(entity);
            entity.ToTable("cn_ContractBoxTypes");
            entity.Property(c => c.Description)
                .HasMaxLength(512);
        }
    }
}
