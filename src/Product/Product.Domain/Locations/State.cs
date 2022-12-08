using Postex.SharedKernel.Domain;
using Product.Domain.Couriers;

namespace Product.Domain.Locations
{
    public class State : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string EnglishName { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<CourierZoneSLA> StateFromCourierZoneSLAs { get; set; }
        public ICollection<CourierZoneSLA> StateToCourierZoneSLAs { get; set; }
    }
}
