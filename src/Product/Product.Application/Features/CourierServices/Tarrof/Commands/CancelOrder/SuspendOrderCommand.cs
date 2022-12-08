using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Post;

namespace Product.Application.Features.CourierServices.Tarrof.Commands.CancelOrder
{
    public class SuspendOrderCommand : ITransactionRequest<BaseResponse<PostSuspendOrderResponse>>
    {
        public List<string> ParcelCodes { get; set; }
    }
}
