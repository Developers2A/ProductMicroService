using AutoMapper;
using Product.Application.Dtos.Commons;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;
using Product.Domain.Locations;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Mappings
{
    public class CourierMapping : Profile
    {
        public CourierMapping()
        {
            CreateMap<Courier, CourierDto>();
            CreateMap<Courier, CourierCommonDto>();
            CreateMap<CourierService, CourierServiceDto>();
            CreateMap<CourierInsurance, CourierInsuranceDto>();
            CreateMap<CourierLimit, CourierLimitDto>();
            CreateMap<CourierCod, CourierCodDto>();
            CreateMap<CourierServiceZone, CourierServiceZoneDto>();
            CreateMap<CourierServiceZonePrice, CourierServiceZonePriceDto>();

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
