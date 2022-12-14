using Postex.SharedKernel.Domain;

namespace Product.Domain.Couriers
{
    public class CourierServiceZonePrice : BaseEntity<int>
    {
        public int CourierServiceZoneId { get; set; }
        public CourierServiceZone CourierServiceZone { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int? WeightId { get; set; }
        public Weight Weight { get; set; }
        public int? VolumeId { get; set; }
    }
}
