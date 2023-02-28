using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Couriers;

namespace Postex.Product.Infrastructure.Data.Configurations.Statuses
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