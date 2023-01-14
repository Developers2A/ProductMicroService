using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Domain;
using Product.Domain.Offlines;

namespace Product.Domain.Couriers
{
    public class Courier : BaseEntity<int>
    {
        public string Name { get; set; }
        public CourierCode Code { get; set; }
        public string? Company { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CourierService> CourierServices { get; set; }
        public ICollection<CourierCityMapping> CourierCityMappings { get; set; }
        public ICollection<CourierZone> CourierZones { get; set; }
        public ICollection<CourierStatusMapping> CourierStatusMappings { get; set; }
    }
}
