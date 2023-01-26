using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Couriers;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations.Offlines
{
    public class CourierCodConfiguration : BaseEntityConfiguration<CourierCod>
    {
        public override void Configure(EntityTypeBuilder<CourierCod> builder)
        {
            base.Configure(builder);
            builder.ToTable("CourierCods");
            builder.Property(i => i.Name)
               .HasMaxLength(200);

            builder.HasOne(i => i.Courier)
               .WithMany(i => i.CourierCods)
               .HasForeignKey(i => i.CourierId);
        }
    }
}