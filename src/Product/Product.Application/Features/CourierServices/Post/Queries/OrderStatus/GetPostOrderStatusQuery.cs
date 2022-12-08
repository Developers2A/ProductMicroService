using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Post;

namespace Product.Application.Features.CourierServices.Post.Queries.OrderStatus
{
    public class GetPostOrderStatusQuery : ITransactionRequest<BaseResponse<List<PostOrderStatusResponse>>>
    {
        public List<string> ParcelCodes { get; set; }
    }
}
