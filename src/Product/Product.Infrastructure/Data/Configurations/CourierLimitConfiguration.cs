using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierLimitConfiguration : IEntityTypeConfiguration<CourierLimit>
    {
        public void Configure(EntityTypeBuilder<CourierLimit> builder)
        {
            builder.ToTable("CourierLimits");

            builder.Property(i => i.Name)
                .HasMaxLength(200);
        }
    }
}