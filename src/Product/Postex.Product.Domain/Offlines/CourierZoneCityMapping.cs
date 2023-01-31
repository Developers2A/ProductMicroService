using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Offlines
{
    public class CourierZoneCityMapping : BaseEntity<int>
    {
        public int CourierZoneId { get; set; }
        public CourierZone CourierZone { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
