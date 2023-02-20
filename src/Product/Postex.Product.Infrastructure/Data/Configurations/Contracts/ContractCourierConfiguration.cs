using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations
{
    public class ContractCourierConfiguration : BaseEntityConfiguration<ContractCourier>
    {
        public override void Configure(EntityTypeBuilder<ContractCourier> entity)
        {
            base.Configure(entity);
            entity.ToTable("cn_ContractCouriers");
            entity.Property(c => c.Description)
                .HasMaxLength(512);
        }
    }
}
