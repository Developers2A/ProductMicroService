using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Couriers
{
    public class Courier : BaseEntity<int>
    {
        public SharedKernel.Common.Enums.CourierCode Code { get; set; }
        public string Name { get; set; }
        public string? Company { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CourierService> CourierServices { get; set; }
        public ICollection<CourierCityMapping> CourierCityMappings { get; set; }
        public ICollection<CourierZone> CourierZones { get; set; }
        public ICollection<CourierStatusMapping> CourierStatusMappings { get; set; }
    }
}
