using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Common;

namespace Postex.Product.Infrastructure.Data.Configurations.Common
{
    public class ValueAddedTypeConfiguration : BaseEntityConfiguration<ValueAddedType>
    {
        public override void Configure(EntityTypeBuilder<ValueAddedType> builder)
        {
            base.Configure(builder);
            builder.ToTable("ValueAddedTypes");

            builder.Property(i => i.Name)
                .HasMaxLength(200);
            builder.HasData(Seed());
        }

        private static object[] Seed()
        {
            var createDate = new DateTime(2023, 2, 28, 12, 12, 0);

            return new object[]
            {
                new ValueAddedType {
                    Id = 1,
                    Name = "پیامک",
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new ValueAddedType
                {
                    Id = 2,
                    Name = "آواتار",
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 3,
                    Name = "لوگو",
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 4,
                    Name = "پرینت",
                    IsRemoved = false,
                    CreatedOn = createDate
                }
            };
        }
    }
}