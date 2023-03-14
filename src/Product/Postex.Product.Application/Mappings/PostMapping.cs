using AutoMapper;
using Postex.Product.Application.Dtos.Posts;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.Product.Domain.Posts;

namespace Postex.Product.Application.Mappings
{
    public class PostMapping : Profile
    {
        public PostMapping()
        {
            CreateMap<PostShopDto, PostShop>().ReverseMap();
            CreateMap<PostCityShopDto, PostCityShop>().ReverseMap();
            CreateMap<PostShop, Shop>()
                .ForMember(dest => dest.ID, y => y.MapFrom(x => x.ShopId));
            CreateMap<Shop, PostShop>()
                .ForMember(dest => dest.ShopId, y => y.MapFrom(x => x.ID))
                .ForMember(dest => dest.Id, y => y.MapFrom(x => 0));
            CreateMap<PostShop, Shop>()
                .ForMember(dest => dest.CityID, y => y.MapFrom(x => x.CityCode))
                .ForMember(dest => dest.ProvinceID, y => y.MapFrom(x => x.ProvinceCode))
                .ReverseMap();
        }
    }
}
