using AutoMapper;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.Offlines;

namespace Postex.Product.Application.Mappings
{
    public class CourierZoneMapping : Profile
    {
        public CourierZoneMapping()
        {
            CreateMap<CourierZone, CourierZoneDto>();
            CreateMap<CourierZoneCityMapping, CourierZoneCityMappingDto>();
        }
    }
}
