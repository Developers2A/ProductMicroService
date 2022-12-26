using Postex.SharedKernel.Domain;

namespace Product.Domain.Offlines
{
    public class CourierZoneCollectionDistributionPrice : BaseEntity<int>
    {
        public CourierZoneCollectionDistributionPrice(decimal buyPrice, decimal sellPrice, int courierZoneId, double volume)
        {
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            CourierZoneId = courierZoneId;
            Volume = volume;
        }

        public void Edit(decimal buyPrice, decimal sellPrice, double volume)
        {
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Volume = volume;
        }

        public int CourierZoneId { get; set; }
        public CourierZone CourierZone { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public double Volume { get; set; }
    }
}