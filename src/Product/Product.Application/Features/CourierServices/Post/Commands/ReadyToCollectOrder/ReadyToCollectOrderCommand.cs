using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Post;

namespace Product.Application.Features.CourierServices.Post.Commands.ReadyToCollectOrder
{
    public class ReadyToCollectOrderCommand : ITransactionRequest<BaseResponse<List<PostReadyToCollectResponse>>>
    {
        public List<string> ParcelCodes { get; set; }
    }
}
