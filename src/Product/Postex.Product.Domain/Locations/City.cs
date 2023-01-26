using Postex.Product.Domain.Couriers;
using Postex.Product.Domain.Offlines;
using Postex.Product.Domain.Posts;
using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Locations
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
        public ICollection<CourierZoneCityMapping> CourierZoneCityMappings { get; set; }
    }
}
