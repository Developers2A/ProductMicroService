using AutoMapper;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Dtos.ServiceProviders.Chapar;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.Product.Application.Dtos.ServiceProviders.Taroff.Dtos;
using Postex.Product.Domain.Locations;

namespace Postex.Product.Application.Mappings
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
