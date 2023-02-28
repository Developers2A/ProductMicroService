using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Commands.ReadyToCollectOrder
{
    public class ReadyToCollectOrderCommand : ITransactionRequest<BaseResponse<List<PostReadyToCollectResponse>>>
    {
        public List<string> ParcelCodes { get; set; }
    }
}
