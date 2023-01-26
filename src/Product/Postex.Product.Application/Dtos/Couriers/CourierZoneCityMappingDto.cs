using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Dtos.Couriers
{
    public class CourierZoneCityMappingDto
    {
        public int CourierZoneId { get; set; }
        public int CityId { get; set; }
        public CourierCode CourierCode { get; set; }
    }
}
