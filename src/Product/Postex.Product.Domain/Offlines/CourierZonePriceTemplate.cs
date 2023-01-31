using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Offlines
{
    public class CourierZonePriceTemplate : BaseEntity<int>
    {
        public string? Name { get; set; }
        public int FromCity { get; set; }
        public int ToCity { get; set; }
        public int CourierServiceId { get; set; }
        public CourierService CourierService { get; set; }
        public int FromCourierZoneId { get; set; }
        public int ToCourierZoneId { get; set; }
        public int Weight { get; set; }
        public bool SameState { get; set; }
    }
}
