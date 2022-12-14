using Postex.SharedKernel.Domain;
using Product.Domain.Couriers;

namespace Product.Domain.Locations
{
    public class Country : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<CourierServiceZone> CourierServiceZones { get; set; }
    }
}
