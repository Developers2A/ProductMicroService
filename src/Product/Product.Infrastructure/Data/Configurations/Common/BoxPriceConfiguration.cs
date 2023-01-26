using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.ValueAddedPrices;

namespace Product.Infrastructure.Data.Configurations.Common
{
    public class BoxPriceConfiguration : BaseEntityConfiguration<BoxSizePrice>
    {
        public override void Configure(EntityTypeBuilder<BoxSizePrice> builder)
        {
            base.Configure(builder);

            builder.ToTable("BoxPrices");

            builder.Property(i => i.Name)
                .HasMaxLength(200);
            //builder.HasData(Seed());
        }

        private static object[] Seed()
        {
            var createDate = new DateTime(2022, 12, 12, 12, 12, 0);
            return new object[]
            {
                new BoxSizePrice {
                    Id = 1,
                    Name = "سایز 1",
                    Height = 10,
                    Width = 10,
                    Length = 15,
                    BuyPrice = 140000,
                    SellPrice = 160000,
                    CreatedOn = createDate
                },
                   new BoxSizePrice
                {
                    Id = 2,
                    Name = "سایز 2",
                    //VolumeOfBox = 3000,
                    Height = 10,
                    Width = 15,
                    Length = 20,
                    BuyPrice = 150000,
                    SellPrice = 170000,
                    CreatedOn = createDate
                },
                new BoxSizePrice
                {
                    Id = 3,
                    Name = "سایز 3",
                    //VolumeOfBox = 6000,
                    Height = 15,
                    Width = 20,
                    Length = 20,
                    BuyPrice = 170000,
                    SellPrice = 190000,
                    CreatedOn = createDate
                },
                new BoxSizePrice
                {
                    Id = 4,
                    Name = "سایز 4",
                    //VolumeOfBox = 12000,
                    Height = 20,
                    Width = 20,
                    Length = 30,
                    BuyPrice = 190000,
                    SellPrice = 210000,
                    CreatedOn = createDate
                },
                new BoxSizePrice
                {
                    Id = 5,
                    Name = "سایز 5",
                    //VolumeOfBox = 17500,
                    Height = 20,
                    Width = 25,
                    Length = 35,
                    BuyPrice = 210000,
                    SellPrice = 230000,
                    CreatedOn = createDate
                },
                new BoxSizePrice
                {
                    Id = 6,
                    Name = "سایز 6",
                    //VolumeOfBox = 31500,
                    Height = 20,
                    Width = 35,
                    Length = 45,
                    BuyPrice = 260000,
                    SellPrice = 280000,
                    CreatedOn = createDate
                },
                new BoxSizePrice
                {
                    Id = 7,
                    Name = "سایز 7",
                    //VolumeOfBox = 30000,
                    Height = 25,
                    Width = 30,
                    Length = 40,
                    BuyPrice = 280000,
                    SellPrice = 300000,
                    CreatedOn = createDate
                },
                new BoxSizePrice
                {
                    Id = 8,
                    Name = "سایز 8",
                    //VolumeOfBox = 54000,
                    Height = 30,
                    Width = 40,
                    Length = 45,
                    BuyPrice = 310000,
                    SellPrice = 330000,
                    CreatedOn = createDate
                },
                new BoxSizePrice
                {
                    Id = 9,
                    Name = "سایز 9",
                    //VolumeOfBox = 30000,
                    Height = 35,
                    Width = 45,
                    Length = 55,
                    BuyPrice = 380000,
                    SellPrice = 400000,
                    CreatedOn = createDate
                },
                new BoxSizePrice
                {
                    Id = 10,
                    Name = " پاکت A5",
                    //VolumeOfBox = 388,
                    Height = 1,
                    Width = 11.5,
                    Length = 22.5,
                    BuyPrice = 130000,
                    SellPrice = 150000,
                    CreatedOn = createDate
                },
                new BoxSizePrice
                {
                    Id = 11,
                    Name = " پاکت A4",
                    //VolumeOfBox = 1063,
                    Height = 1,
                    Width = 22.5,
                    Length = 31.5,
                    BuyPrice = 140000,
                    SellPrice = 160000,
                    CreatedOn = createDate
                },
                new BoxSizePrice
                {
                    Id = 12,
                    Name = " پاکت A3",
                    //VolumeOfBox = 2100,
                    Height = 1,
                    Width = 30.5,
                    Length = 45.8,
                    BuyPrice = 140000,
                    SellPrice = 160000,
                    CreatedOn = createDate
                }
            };
        }

    }
}