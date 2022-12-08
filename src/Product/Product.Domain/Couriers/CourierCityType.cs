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

        public CourierCityType(int courierId, int cityId, CityType cityType)
        {
            CourierId = courierId;
            CityId = cityId;
            CityType = cityType;
        }

        public void Edit(int courierId, int cityId, CityType cityType)
        {
            CourierId = courierId;
            CityId = cityId;
            CityType = cityType;
        }

        public int CourierId { get; set; }
        public Courier Courier { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public CityType CityType { get; set; }
    }
}