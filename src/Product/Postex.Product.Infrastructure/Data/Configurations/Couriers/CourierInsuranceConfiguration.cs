using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Couriers;

namespace Postex.Product.Infrastructure.Data.Configurations.Couriers
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