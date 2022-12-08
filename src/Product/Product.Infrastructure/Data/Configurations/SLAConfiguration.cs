using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class SLAConfiguration : IEntityTypeConfiguration<SLA>
    {
        public void Configure(EntityTypeBuilder<SLA> builder)
        {
            builder.ToTable("SLAs");

            builder.Property(i => i.Name)
                .HasMaxLength(200);

            builder.Property(i => i.Days)
                .HasMaxLength(200);
        }
    }
}