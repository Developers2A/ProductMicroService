using Postex.SharedKernel.Domain;

namespace Product.Domain.Couriers
{
    public class CourierZoneSLAPrice : BaseEntity<int>
    {
        public int CourierZoneSlAId { get; set; }
        public CourierZoneSLA CourierZoneSlA { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int? WeightId { get; set; }
        public Weight Weight { get; set; }
        public int? VolumeId { get; set; }
    }
}
