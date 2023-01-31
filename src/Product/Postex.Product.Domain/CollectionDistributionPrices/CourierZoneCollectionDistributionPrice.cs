using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.CollectionDistributionPrices
{
    public class CourierZoneCollectionDistributionPrice : BaseEntity<int>
    {
        public int CourierZoneId { get; set; }
        public CourierZone CourierZone { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public double Volume { get; set; }
    }
}