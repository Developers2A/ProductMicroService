using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;
using Product.Infrastructure.Data.Configurations.Common;

namespace Product.Infrastructure.Data.Configurations.Couriers
{
    public class CourierServiceConfiguration : BaseEntityConfiguration<CourierService>
    {
        public override void Configure(EntityTypeBuilder<CourierService> builder)
        {
            base.Configure(builder);

            builder.ToTable("CourierServices");

            builder.Property(i => i.Name)
                .HasMaxLength(200);

            builder.HasOne(i => i.Courier)
                .WithMany(i => i.CourierServices)
                .HasForeignKey(i => i.CourierId);
        }
    }
}