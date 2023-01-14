using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Domain;
using Product.Domain.Couriers;

namespace Product.Domain.Offlines
{
    public class CourierZone : BaseEntity<int>
    {
        public int CourierId { get; set; }
        public Courier Courier { get; set; }
        public string Name { get; set; }
        public CityTypeCode Code { get; set; }

        public ICollection<CourierZonePrice> FromCourierZonePrices { get; set; }
        public ICollection<CourierZonePrice> ToCourierZonePrices { get; set; }
        public ICollection<CourierZoneCityMapping> CourierZoneCityMappings { get; set; }

    }
}
