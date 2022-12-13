using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Post;

namespace Product.Application.Features.CourierServices.Post.Queries.GetStatus
{
    public class GetPostStatusQuery : ITransactionRequest<BaseResponse<List<PostOrderStatusResponse>>>
    {
        public List<string> ParcelCodes { get; set; }
    }
}
