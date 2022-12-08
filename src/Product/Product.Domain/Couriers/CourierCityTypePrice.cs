using Postex.SharedKernel.Domain;
using Product.Domain.Enums;

namespace Product.Domain.Couriers
{
    public class CourierCityTypePrice : BaseEntity<int>
    {
        public CourierCityTypePrice(decimal buyPrice, decimal sellPrice, int courierId, CityType cityType, double volume)
        {
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            CourierId = courierId;
            CityType = cityType;
            Volume = volume;
        }

        public void Edit(decimal buyPrice, decimal sellPrice, double volume)
        {
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Volume = volume;
        }

        public CityType CityType { get; set; }
        public int CourierId { get; set; }
        public Courier Courier { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public double Volume { get; set; }
    }
}