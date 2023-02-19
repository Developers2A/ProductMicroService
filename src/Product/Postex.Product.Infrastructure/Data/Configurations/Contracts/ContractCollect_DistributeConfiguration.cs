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
    public class ContractCollect_DistributeConfiguration:BaseEntityConfiguration<ContractCollect_Distribute>
    {
        public override void Configure(EntityTypeBuilder<ContractCollect_Distribute> entity)
        {
            base.Configure(entity);
            entity.ToTable("cn_ContractCollect_Distributes");
            entity.Property(c => c.Description)
                .HasMaxLength(512);
        }
    }
}
