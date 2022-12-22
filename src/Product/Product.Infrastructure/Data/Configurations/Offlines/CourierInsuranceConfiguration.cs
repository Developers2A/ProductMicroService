using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;
using Product.Infrastructure.Data.Configurations.Common;

namespace Product.Infrastructure.Data.Configurations.Offlines
{
    public class CourierInsuranceConfiguration : BaseEntityConfiguration<CourierInsurance>
    {
        public override void Configure(EntityTypeBuilder<CourierInsurance> builder)
        {
            base.Configure(builder);
            builder.ToTable("CourierInsurances");
            builder.Property(i => i.Name)
               .HasMaxLength(200);

            builder.HasOne(i => i.Courier)
               .WithMany(i => i.CourierInsurances)
               .HasForeignKey(i => i.CourierId);
        }
    }
}