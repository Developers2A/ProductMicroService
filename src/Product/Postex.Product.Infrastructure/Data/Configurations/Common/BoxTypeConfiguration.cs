using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain.Common;

namespace Postex.Product.Infrastructure.Data.Configurations.Common
{
    public class BoxTypeConfiguration : BaseEntityConfiguration<BoxType>
    {
        public override void Configure(EntityTypeBuilder<BoxType> builder)
        {
            base.Configure(builder);
            builder.ToTable("BoxTypes");
            builder.HasData(Seed());
        }

        private static object[] Seed()
        {
            var createDate = new DateTime(2022, 12, 12, 12, 12, 0);
            return new object[]
            {
                new BoxType {
                    Id = 1,
                    Name = "سایز 1",
                    Height = 10,
                    Width = 10,
                    Length = 15,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                   new BoxType
                {
                    Id = 2,
                    Name = "سایز 2",
                    //VolumeOfBox = 3000,
                    Height = 10,
                    Width = 15,
                    Length = 20,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 3,
                    Name = "سایز 3",
                    //VolumeOfBox = 6000,
                    Height = 15,
                    Width = 20,
                    Length = 20,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 4,
                    Name = "سایز 4",
                    //VolumeOfBox = 12000,
                    Height = 20,
                    Width = 20,
                    Length = 30,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 5,
                    Name = "سایز 5",
                    //VolumeOfBox = 17500,
                    Height = 20,
                    Width = 25,
                    Length = 35,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 6,
                    Name = "سایز 6",
                    //VolumeOfBox = 31500,
                    Height = 20,
                    Width = 35,
                    Length = 45,
                    IsRemoved = false,
                    CreatedOn = createDate
                }
            };
        }
    }
}
