using AutoMapper;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Dtos.CourierStatus;
using Postex.Product.Domain.Common;
using Postex.Product.Domain.Couriers;
using Postex.Product.Domain.Locations;
using Postex.Product.Domain.Offlines;

namespace Postex.Product.Application.Mappings
{
    public class CourierMapping : Profile
    {
        public CourierMapping()
        {
            CreateMap<CourierService, CourierServiceDto>();
            CreateMap<Courier, CourierCommonDto>();
            CreateMap<CourierService, CourierServiceCommonDto>();
            CreateMap<CourierInsurance, CourierInsuranceDto>();
            CreateMap<CourierLimit, CourierLimitDto>();
            CreateMap<CourierCod, CourierCodDto>();
            CreateMap<CourierZone, CourierZoneDto>();
            CreateMap<CourierZonePrice, CourierZonePriceDto>();
            CreateMap<Courier, CourierDto>();
            CreateMap<CourierStatusMapping, CourierStatusMappingDto>();
            CreateMap<CourierCityMapping, CourierCityMappingDto>().ReverseMap();
            CreateMap<Zone, ZoneDto>();
            CreateMap<Weight, WeightDto>();
            CreateMap<BoxType, BoxTypeDto>();
        }
    }
}
