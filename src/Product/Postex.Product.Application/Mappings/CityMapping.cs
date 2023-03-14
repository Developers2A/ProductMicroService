using AutoMapper;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Domain.Locations;

namespace Postex.Product.Application.Mappings
{
    public class CityMapping : Profile
    {
        public CityMapping()
        {
            CreateMap<City, CityDto>();
            CreateMap<Province, ProvinceDto>();
            CreateMap<City, CityCommonDto>();
            CreateMap<Province, ProvinceCommonDto>();
        }
    }
}
