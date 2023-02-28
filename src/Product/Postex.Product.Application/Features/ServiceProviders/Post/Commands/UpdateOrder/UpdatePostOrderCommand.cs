using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Commands.UpdateOrder
{
    public class UpdatePostOrderCommand : ITransactionRequest<BaseResponse<PostEditOrderResponse>>
    {
        public int ShopID { get; set; }
        public string ParcelCode { get; set; }
        public string CustomerNID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerFamily { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPostalCode { get; set; }
        public string CustomerAddress { get; set; }
        public string ParcelContent { get; set; }
    }
}
