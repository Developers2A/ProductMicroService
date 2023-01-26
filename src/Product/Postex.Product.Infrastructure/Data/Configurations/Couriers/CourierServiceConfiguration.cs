using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Couriers;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations.Couriers
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