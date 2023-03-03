using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Contract.Domain;

namespace Postex.Contract.Infrastructure
{
    public class BoxTypeConfiguration : BaseEntityConfiguration<BoxType>
    {
        public override void Configure(EntityTypeBuilder<BoxType> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.Name)
                .HasMaxLength(200);
        }
    }
}
