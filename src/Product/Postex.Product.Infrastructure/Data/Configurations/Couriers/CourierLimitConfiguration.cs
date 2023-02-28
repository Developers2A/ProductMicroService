using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Couriers;

namespace Postex.Product.Infrastructure.Data.Configurations.Couriers
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