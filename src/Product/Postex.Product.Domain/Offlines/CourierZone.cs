using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Offlines
{
    public class CourierZone : BaseEntity<int>
    {
        public int CourierId { get; set; }
        public Courier Courier { get; set; }
        public string Name { get; set; }
        public CityTypeCode CityType { get; set; }
        public decimal EntryPrice { get; set; }

        public ICollection<CourierZonePrice> FromCourierZonePrices { get; set; }
        public ICollection<CourierZonePrice> ToCourierZonePrices { get; set; }
        public ICollection<CourierZoneCityMapping> CourierZoneCityMappings { get; set; }

    }
}
