using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;
using Product.Infrastructure.Data.Configurations.Common;

namespace Product.Infrastructure.Data.Configurations.Statuses
{
    public class CourierStatusMappingConfiguration : BaseEntityConfiguration<CourierStatusMapping>
    {
        public override void Configure(EntityTypeBuilder<CourierStatusMapping> builder)
        {
            base.Configure(builder);

            builder.ToTable("CourierStatusMappings");

            builder.Property(i => i.Code)
                .HasMaxLength(200);

            builder.Property(i => i.Description)
                .HasMaxLength(200);

            builder.HasOne(i => i.Courier)
               .WithMany(i => i.CourierStatusMappings)
               .HasForeignKey(i => i.CourierId);

            builder.HasOne(i => i.Status)
               .WithMany(i => i.CourierStatusMappings)
               .HasForeignKey(i => i.StatusId);
        }
    }
}