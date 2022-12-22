using Postex.SharedKernel.Domain;
using Product.Domain.Locations;

namespace Product.Domain.Couriers
{
    public class CourierLimitValue : BaseEntity<int>
    {
        public int CourierId { get; set; }
        public CourierService Courier { get; set; }
        public int CourierLimitId { get; set; }
        public CourierLimit CourierLimit { get; set; }
        public float LowerLimit { get; set; }
        public float UpperLimit { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
        public int FromOrToType { get; set; }
    }
}
