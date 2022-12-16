using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class StatusConfiguration : BaseEntityConfiguration<Status>
    {
        public override void Configure(EntityTypeBuilder<Status> builder)
        {
            base.Configure(builder);
            builder.ToTable("Statuses");

            builder.Property(i => i.Name)
                .HasMaxLength(200);

            builder.Property(i => i.Description)
                .HasMaxLength(200);

            builder.Property(i => i.Code)
                .HasMaxLength(200);

            builder.Property(i => i.Type)
                .HasMaxLength(200);
        }
    }
}