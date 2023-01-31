using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetNodes
{
    public class GetPostNodesQuery : ITransactionRequest<BaseResponse<List<PostGetNodesResponse>>>
    {
        public int CityId { get; set; }
    }
}
