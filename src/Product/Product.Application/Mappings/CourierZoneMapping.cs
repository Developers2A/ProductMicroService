using AutoMapper;
using Product.Application.Dtos.Couriers;
using Product.Domain.Offlines;

namespace Product.Application.Mappings
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
