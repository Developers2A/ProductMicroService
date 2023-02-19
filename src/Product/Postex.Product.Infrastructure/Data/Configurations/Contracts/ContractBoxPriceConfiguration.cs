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
    public class ContractBoxPriceConfiguration:BaseEntityConfiguration<ContractBoxPrice>
    {
        public override void Configure(EntityTypeBuilder<ContractBoxPrice> entity)
        {
            base.Configure(entity);
            entity.ToTable("cn_ContractBoxPrices");
            entity.Property(c => c.Description)
                .HasMaxLength(512);
        }
    }
}
