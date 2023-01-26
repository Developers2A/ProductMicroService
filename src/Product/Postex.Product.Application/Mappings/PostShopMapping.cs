using AutoMapper;
using Postex.Product.Application.Dtos.PostShops;
using Postex.Product.Domain.Posts;

namespace Postex.Product.Application.Mappings
{
    public class PostShopMapping : Profile
    {
        public PostShopMapping()
        {
            CreateMap<PostShopDto, PostShop>().ReverseMap();
        }
    }
}
