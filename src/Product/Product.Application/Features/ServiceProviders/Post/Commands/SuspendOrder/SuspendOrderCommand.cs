using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Post;

namespace Product.Application.Features.ServiceProviders.Post.Commands.SuspendOrder
{
    public class SuspendOrderCommand : ITransactionRequest<BaseResponse<List<PostSuspendOrderResponse>>>
    {
        public List<string> ParcelCodes { get; set; }
    }
}
