using Postex.SharedKernel.Domain;
using Product.Domain.Couriers;
using Product.Domain.Offlines;
using ServiceProvider.Domain.Couriers;

namespace Product.Domain.Locations
{
    public class City : BaseEntity<int>
    {
        public int StateId { get; set; }
        public State State { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string? EnglishName { get; set; }

        public ICollection<CityZipCode> CityZipCodes { get; set; }
        public ICollection<CourierCityMapping> CourierCityMappings { get; set; }
        public ICollection<CourierCityType> CourierCityTypes { get; set; }
        public ICollection<CourierZoneCityMapping> CourierZoneCityMappings { get; set; }
    }
}
