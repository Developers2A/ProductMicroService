using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Commands.DeleteOrder
{
    public class DeletePostOrderCommand : ITransactionRequest<BaseResponse<List<PostDeleteOrderResponse>>>
    {
        public List<string> ParcelCodes { get; set; }
    }
}
