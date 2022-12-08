using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Statuses");

            builder.Property(i => i.Name)
                .HasMaxLength(200);

            builder.Property(i => i.Description)
                .HasMaxLength(200);

            builder.Property(i => i.Order)
                .HasMaxLength(200);

            builder.Property(i => i.Code)
                .HasMaxLength(200);

            builder.Property(i => i.Type)
                .HasMaxLength(200);
        }
    }
}