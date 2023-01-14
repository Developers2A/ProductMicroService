using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Contract.Infrastructure;

namespace Postex.Contract.Domain
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
