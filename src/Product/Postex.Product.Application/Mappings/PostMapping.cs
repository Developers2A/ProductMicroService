using AutoMapper;
using Postex.Product.Application.Dtos.Posts;
using Postex.Product.Domain.Posts;

namespace Postex.Product.Application.Mappings
{
    public class PostMapping : Profile
    {
        public PostMapping()
        {
            CreateMap<PostShopDto, PostShop>().ReverseMap();
            CreateMap<PostCityShopDto, PostCityShop>().ReverseMap();
        }
    }
}
