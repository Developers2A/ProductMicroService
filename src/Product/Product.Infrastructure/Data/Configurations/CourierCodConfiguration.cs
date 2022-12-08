using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierCodConfiguration : IEntityTypeConfiguration<CourierCod>
    {
        public void Configure(EntityTypeBuilder<CourierCod> builder)
        {
            builder.ToTable("CourierCods");
            builder.Property(i => i.Name)
               .HasMaxLength(200);

            builder.HasOne(i => i.Courier)
               .WithMany(i => i.CourierCods)
               .HasForeignKey(i => i.CourierId);
        }
    }
}