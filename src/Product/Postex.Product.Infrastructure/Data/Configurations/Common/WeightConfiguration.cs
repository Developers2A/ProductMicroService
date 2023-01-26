using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Couriers;

namespace Postex.Product.Infrastructure.Data.Configurations.Common
{
    public class WeightConfiguration : BaseEntityConfiguration<Weight>
    {
        public override void Configure(EntityTypeBuilder<Weight> builder)
        {
            base.Configure(builder);
            builder.ToTable("Weights");

            builder.Property(i => i.Code)
                .HasMaxLength(200);
        }
    }
}