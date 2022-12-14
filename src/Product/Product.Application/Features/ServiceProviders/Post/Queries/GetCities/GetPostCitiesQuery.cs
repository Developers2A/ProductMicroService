using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Post;

namespace Product.Application.Features.ServiceProviders.Post.Queries.GetCities
{
    public class GetPostCitiesQuery : ITransactionRequest<BaseResponse<List<PostGetCitiesResponse>>>
    {
        public int ProvinceId { get; set; }
    }
}
