using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetCities
{
    public class GetPostCitiesQuery : ITransactionRequest<BaseResponse<List<PostGetCitiesResponse>>>
    {
        public int ProvinceId { get; set; }
    }
}
