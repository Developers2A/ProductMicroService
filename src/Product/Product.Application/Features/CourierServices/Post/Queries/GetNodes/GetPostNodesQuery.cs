using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Post;

namespace Product.Application.Features.CourierServices.Post.Queries.GetNodes
{
    public class GetPostNodesQuery : ITransactionRequest<BaseResponse<List<PostGetNodesResponse>>>
    {
        public int CityId { get; set; }
    }
}
