using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Commands.SuspendOrder
{
    public class SuspendPostOrderCommand : ITransactionRequest<BaseResponse<List<PostSuspendOrderResponse>>>
    {
        public List<string> ParcelCodes { get; set; }
    }
}
