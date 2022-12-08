using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Post;

namespace Product.Application.Features.CourierServices.Post.Commands.UpdateOrder
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
