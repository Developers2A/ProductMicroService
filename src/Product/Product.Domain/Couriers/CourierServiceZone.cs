using Postex.SharedKernel.Domain;
using Product.Domain.Locations;

namespace Product.Domain.Couriers
{
    public class CourierServiceZone : BaseEntity<int>
    {
        public int CourierId { get; set; }
        public Courier Courier { get; set; }
        public int StateFromId { get; set; }
        public State StateFrom { get; set; }
        public int StateToId { get; set; }
        public State StateTo { get; set; }
        public int? CityFromId { get; set; }
        public City CityFrom { get; set; }
        public int? CityToId { get; set; }
        public City CityTo { get; set; }
        public int? ZoneId { get; set; }
        public Zone Zone { get; set; }
        public int? CourierServiceId { get; set; }
        public CourierService CourierService { get; set; }
        public int Days { get; set; }
        public bool HasCollection { get; set; }
        public bool HasDistribution { get; set; }
        public int? CountryToId { get; set; }
        public Country CountryTo { get; set; }
        public int? ForeignPostType { get; set; }

        public ICollection<CourierServiceZonePrice> CourierServiceZonePrices { get; set; }
    }
}
