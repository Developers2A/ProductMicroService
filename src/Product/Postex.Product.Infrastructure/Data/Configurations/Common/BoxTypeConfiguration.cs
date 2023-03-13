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
                    Name = "سایز A5(22*11)",
                    Height = 2,
                    Width = 11,
                    Length = 22,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 2,
                    Name = "سایز A4(31*22)",
                    Height = 22,
                    Width = 22,
                    Length = 31,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 3,
                    Name = "سایز A3(30*45)",
                    Height = 2,
                    Width = 30,
                    Length = 45,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 4,
                    Name = "سایز 1(10*10*15)",
                    Height = 15,
                    Width = 10,
                    Length = 10,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 5,
                    Name = "سایز 2(10*15*20)",
                    Height = 20,
                    Width = 10,
                    Length = 15,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 6,
                    Name = "سایز 3(15*20*20)",
                    Height = 20,
                    Width = 15,
                    Length = 20,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 7,
                    Name = "سایز 4(20*20*30)",
                    Height = 30,
                    Width = 20,
                    Length = 20,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 8,
                    Name = "سایز 5(20*25*35)",
                    Height = 35,
                    Width = 25,
                    Length = 25,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 9,
                    Name = "سایز 6(20*35*45)",
                    Height = 45,
                    Width = 20,
                    Length = 35,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 10,
                    Name = "سایز 7(25*30*40)",
                    Height = 40,
                    Width = 25,
                    Length = 30,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 11,
                    Name = "سایز 8(30*40*45)",
                    Height = 45,
                    Width = 30,
                    Length = 40,
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new BoxType
                {
                    Id = 12,
                    Name = "سایز 9(35*45*55)",
                    Height = 50,
                    Width = 35,
                    Length = 45,
                    IsRemoved = false,
                    CreatedOn = createDate
                }
            };
        }
    }
}
