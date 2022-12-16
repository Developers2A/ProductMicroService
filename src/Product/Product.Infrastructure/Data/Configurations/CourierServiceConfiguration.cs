using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierServiceConfiguration : BaseEntityConfiguration<CourierService>
    {
        public override void Configure(EntityTypeBuilder<CourierService> builder)
        {
            base.Configure(builder);
            builder.ToTable("CourierServices");

            builder.Property(i => i.Name)
                .HasMaxLength(200);

            builder.Property(i => i.Days)
                .HasMaxLength(200);

            builder.HasOne(i => i.Courier)
                .WithMany(i => i.CourierServices)
                .HasForeignKey(i => i.CourierId);
        }
    }
}