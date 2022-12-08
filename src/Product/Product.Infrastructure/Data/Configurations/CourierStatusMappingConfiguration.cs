using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierStatusMappingConfiguration : IEntityTypeConfiguration<CourierStatusMapping>
    {
        public void Configure(EntityTypeBuilder<CourierStatusMapping> builder)
        {
            builder.ToTable("CourierStatusMappings");

            builder.Property(i => i.Code)
                .HasMaxLength(200);

            builder.Property(i => i.Description)
                .HasMaxLength(200);

            builder.HasOne(i => i.CourierApi)
               .WithMany(i => i.CourierStatusMappings)
               .HasForeignKey(i => i.CourierApiId);

            builder.HasOne(i => i.Status)
               .WithMany(i => i.CourierStatusMappings)
               .HasForeignKey(i => i.StatusId);
        }
    }
}