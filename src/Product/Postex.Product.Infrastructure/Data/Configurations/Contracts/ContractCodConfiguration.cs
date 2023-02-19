using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain;
using Postex.Product.Infrastructure.Data.Configurations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Infrastructure.Data.Configurations
{
    public class ContractCodConfiguration:BaseEntityConfiguration<ContractCod>
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
