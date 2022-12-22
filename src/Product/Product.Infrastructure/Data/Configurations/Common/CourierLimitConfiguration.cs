using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations.Common
{
    public class CourierLimitConfiguration : BaseEntityConfiguration<CourierLimit>
    {
        public override void Configure(EntityTypeBuilder<CourierLimit> builder)
        {
            base.Configure(builder);
            builder.ToTable("CourierLimits");

            builder.Property(i => i.Name)
                .HasMaxLength(200);
        }
    }
}