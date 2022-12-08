using Postex.SharedKernel.Domain;
using Product.Domain.Couriers;

namespace Product.Domain.Locations
{
    public class Zone : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<CourierZoneSLA> CourierZoneSLAs { get; set; }
    }
}
