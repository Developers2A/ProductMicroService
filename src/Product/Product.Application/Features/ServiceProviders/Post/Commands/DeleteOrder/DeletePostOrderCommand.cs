using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Post;

namespace Product.Application.Features.ServiceProviders.Post.Commands.DeleteOrder
{
    public class DeletePostOrderCommand : ITransactionRequest<BaseResponse<List<PostDeleteOrderResponse>>>
    {
        public List<string> ParcelCodes { get; set; }
    }
}
