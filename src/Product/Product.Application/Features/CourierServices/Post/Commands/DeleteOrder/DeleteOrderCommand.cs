using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Post;

namespace Product.Application.Features.CourierServices.Post.Commands.DeleteOrder
{
    public class DeleteOrderCommand : ITransactionRequest<BaseResponse<List<PostDeleteOrderResponse>>>
    {
        public List<string> ParcelCodes { get; set; }
    }
}
