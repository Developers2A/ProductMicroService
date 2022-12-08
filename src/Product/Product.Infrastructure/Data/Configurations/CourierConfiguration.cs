using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierConfiguration : IEntityTypeConfiguration<Courier>
    {
        public void Configure(EntityTypeBuilder<Courier> builder)
        {
            builder.ToTable("Couriers");

            builder.Property(i => i.Name)
                .HasMaxLength(200);

            builder.Property(i => i.Company)
               .HasMaxLength(200);
        }
    }
}