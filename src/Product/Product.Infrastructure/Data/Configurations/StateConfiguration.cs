using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Locations;

namespace Product.Infrastructure.Data.Configurations
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("States");

            builder.Property(i => i.Name)
                .HasMaxLength(200);

            builder.Property(i => i.Code)
                .HasMaxLength(200);

            builder.Property(i => i.EnglishName)
                .HasMaxLength(200);
        }
    }
}