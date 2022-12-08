using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Post;

namespace Product.Application.Features.CourierServices.Tarrof.Commands.ReadyOrder
{
    public class ReadyToCollectOrderCommand : ITransactionRequest<BaseResponse<PostReadyToCollectResponse>>
    {
        public List<string> ParcelCodes { get; set; }
    }
}
