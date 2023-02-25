using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Contracts;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations
{
    public class ContractValueAddedConfiguration : BaseEntityConfiguration<ContractValueAdded>
    {
        public override void Configure(EntityTypeBuilder<ContractValueAdded> entity)
        {
            base.Configure(entity);
            entity.ToTable("ContractValueAddeds");
            entity.Property(c => c.Description)
                .HasMaxLength(512);

            entity.HasOne(i => i.ContractItemType)
                .WithMany(i => i.ContractValueAddeds)
                .HasForeignKey(i => i.ValueAddedTypeId);
        }
    }
}
