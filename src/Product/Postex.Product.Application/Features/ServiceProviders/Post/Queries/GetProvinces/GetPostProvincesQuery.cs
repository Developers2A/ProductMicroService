using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetProvinces
{
    public class GetPostProvincesQuery : ITransactionRequest<BaseResponse<List<PostGetProvincesResponse>>>
    {
    }
}
