using AutoMapper;
using Product.Application.Dtos.Commons;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;
using Product.Domain.Locations;
using Product.Domain.Offlines;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Mappings
{
    public class CourierMapping : Profile
    {
        public CourierMapping()
        {
            CreateMap<CourierService, CourierServiceDto>();
            CreateMap<CourierService, CourierCommonDto>();
            CreateMap<CourierInsurance, CourierInsuranceDto>();
            CreateMap<CourierLimit, CourierLimitDto>();
            CreateMap<CourierCod, CourierCodDto>();
            CreateMap<CourierZone, CourierZoneDto>();
            CreateMap<CourierZonePrice, CourierZonePriceDto>();

            CreateMap<CourierStatusMapping, CourierStatusMappingDto>();
            CreateMap<CourierCityMapping, CourierCityMappingDto>();
            CreateMap<ValueAddedPrice, ValueAddedPriceDto>();
            CreateMap<Zone, ZoneDto>();
            CreateMap<Weight, WeightDto>();
            CreateMap<BoxPrice, BoxPriceDto>();
            //CreateMap<Status, StatusDto>();
        }
    }
}
