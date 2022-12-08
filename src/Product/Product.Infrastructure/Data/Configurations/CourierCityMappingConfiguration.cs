using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Couriers;

namespace Product.Infrastructure.Data.Configurations
{
    public class CourierCityMappingConfiguration : IEntityTypeConfiguration<CourierCityMapping>
    {
        public void Configure(EntityTypeBuilder<CourierCityMapping> builder)
        {
            builder.ToTable("CourierCityMappings");

            builder.Property(i => i.MappedCode)
                .HasMaxLength(200);
        }
    }
}