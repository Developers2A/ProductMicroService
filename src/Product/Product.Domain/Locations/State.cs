using Postex.SharedKernel.Domain;
using Product.Domain.Couriers;

namespace Product.Domain.Locations
{
    public class State : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? EnglishName { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<CourierServiceZone> StateFromCourierServiceZones { get; set; }
        public ICollection<CourierServiceZone> StateToCourierServiceZones { get; set; }
    }
}
