using AutoMapper;
using Product.Application.Dtos.Commons;
using Product.Application.Dtos.CourierServices.Chapar;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Dtos.CourierServices.Post;
using Product.Application.Dtos.CourierServices.Taroff.Dtos;
using Product.Domain.Locations;

namespace Product.Application.Mappings
{
    public class CityMapping : Profile
    {
        public CityMapping()
        {
            CreateMap<City, CityDto>();
            CreateMap<State, StateDto>();
            CreateMap<City, CityCommonDto>();
            CreateMap<State, StateCommonDto>();

            CreateMap<PostGetStatesResponse, CourierStateDto>()
                .ForMember(dest => dest.Name,
                    opts => opts.MapFrom(src => src.Title));

            CreateMap<ChaparState, CourierStateDto>()
                .ForMember(dest => dest.Id,
                  opts => opts.MapFrom(src => src.No));

            CreateMap<PostGetCitiesResponse, CourierCityDto>()
              .ForMember(dest => dest.Name,
                  opts => opts.MapFrom(src => src.Title));

            CreateMap<ChaparCity, CourierCityDto>()
                .ForMember(dest => dest.Id,
                  opts => opts.MapFrom(src => src.No));

            CreateMap<TaroffState, CourierStateDto>()
               .ForMember(dest => dest.Name,
                 opts => opts.MapFrom(src => src.Title));


            CreateMap<TaroffState, CourierCityDto>()
               .ForMember(dest => dest.Name,
                 opts => opts.MapFrom(src => src.Title));
        }
    }
}
