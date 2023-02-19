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
    public class ContractInsuranceConfiguration:BaseEntityConfiguration<ContractInsurance>
    {
        public override void Configure(EntityTypeBuilder<ContractInsurance> entity)
        {
            base.Configure(entity);
            entity.ToTable("cn_ContractInsurances");
            entity.Property(c => c.Description)
                .HasMaxLength(512);

            
        }
    }
}
