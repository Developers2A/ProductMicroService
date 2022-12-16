using AutoMapper;
using Product.Application.Dtos.PostShops;
using Product.Domain.Posts;

namespace Product.Application.Mappings
{
    public class PostShopMapping : Profile
    {
        public PostShopMapping()
        {
            CreateMap<PostShopDto, PostShop>().ReverseMap();
        }
    }
}
