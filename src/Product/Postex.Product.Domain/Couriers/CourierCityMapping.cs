using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Couriers
{
    public class CourierCityMapping : BaseEntity<int>
    {
        public int CourierId { get; set; }
        public Courier Courier { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int Code { get; set; }
        public string MappedCode { get; set; }
    }
}
