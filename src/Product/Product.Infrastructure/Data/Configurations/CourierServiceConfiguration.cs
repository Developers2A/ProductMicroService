using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierServiceConfiguration : IEntityTypeConfiguration<CourierService>
    {
        public void Configure(EntityTypeBuilder<CourierService> builder)
        {
            builder.ToTable("CourierServices");

            builder.Property(i => i.Name)
                .HasMaxLength(200);

            builder.Property(i => i.Days)
                .HasMaxLength(200);
        }
    }
}