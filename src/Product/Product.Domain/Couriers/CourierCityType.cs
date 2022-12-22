using Postex.SharedKernel.Domain;
using Product.Domain.Enums;
using Product.Domain.Locations;

namespace Product.Domain.Couriers
{
    public class CourierCityType : BaseEntity<int>
    {
        public CourierCityType()
        {
        }

        public CourierCityType(int courierId, int cityId, CityTypeCode cityType)
        {
            CourierId = courierId;
            CityId = cityId;
            CityType = cityType;
        }

        public void Edit(int courierId, int cityId, CityTypeCode cityType)
        {
            CourierId = courierId;
            CityId = cityId;
            CityType = cityType;
        }

        public int CourierId { get; set; }
        public CourierService Courier { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public CityTypeCode CityType { get; set; }
    }
}