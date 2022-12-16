using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierApiConfiguration : BaseEntityConfiguration<CourierApi>
    {
        public override void Configure(EntityTypeBuilder<CourierApi> builder)
        {
            base.Configure(builder);

            builder.ToTable("CourierApis");
            builder.Property(i => i.Name)
               .HasMaxLength(200);
            builder.Property(i => i.Version)
              .HasMaxLength(200);

            builder.HasOne(i => i.Courier)
               .WithMany(i => i.CourierApis)
               .HasForeignKey(i => i.CourierId);
        }
    }
}