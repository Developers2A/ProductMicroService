using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Post;

namespace Product.Application.Features.CourierServices.Tarrof.Commands.DeleteOrder
{
    public class DeleteOrderCommand : ITransactionRequest<BaseResponse<PostDeleteOrderResponse>>
    {
        public List<string> ParcelCodes { get; set; }
    }
}
