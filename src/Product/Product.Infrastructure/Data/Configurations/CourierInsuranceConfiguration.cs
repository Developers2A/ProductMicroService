using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierInsuranceConfiguration : IEntityTypeConfiguration<CourierInsurance>
    {
        public void Configure(EntityTypeBuilder<CourierInsurance> builder)
        {
            builder.ToTable("CourierInsurances");
            builder.Property(i => i.Name)
               .HasMaxLength(200);

            builder.HasOne(i => i.Courier)
               .WithMany(i => i.CourierInsurances)
               .HasForeignKey(i => i.CourierId);
        }
    }
}