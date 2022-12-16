using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierLimitValueConfiguration : BaseEntityConfiguration<CourierLimitValue>
    {
        public override void Configure(EntityTypeBuilder<CourierLimitValue> builder)
        {
            base.Configure(builder);
            builder.ToTable("CourierLimitValues");

            builder.HasOne(i => i.Courier)
               .WithMany(i => i.CourierLimitValues)
               .HasForeignKey(i => i.CourierId);

            builder.HasOne(i => i.CourierLimit)
               .WithMany(i => i.CourierLimitValues)
               .HasForeignKey(i => i.CourierLimitId);
        }
    }
}