using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Offlines
{
    public class CourierZonePrice : BaseEntity<int>
    {
        public int CourierServiceId { get; set; }
        public CourierService CourierService { get; set; }
        public int FromCourierZoneId { get; set; }
        public CourierZone FromCourierZone { get; set; }
        public int ToCourierZoneId { get; set; }
        public CourierZone ToCourierZone { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int Weight { get; set; }
        public bool SameProvince { get; set; }
    }
}
