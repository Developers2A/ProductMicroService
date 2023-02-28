using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;

namespace Postex.Product.Infrastructure.Data.Configurations.Contracts
{
    public class ContractCourierConfiguration : BaseEntityConfiguration<ContractCourier>
    {
        public override void Configure(EntityTypeBuilder<ContractCourier> entity)
        {
            base.Configure(entity);
            entity.ToTable("ContractCouriers");
            entity.Property(c => c.Description)
                .HasMaxLength(512);
        }
    }
}
