using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Commands.CreateOrder
{
    public class CreatePostOrderCommand : ITransactionRequest<BaseResponse<PostCreateOrderResponse>>
    {
        public string ClientOrderID { get; set; }
        public string CustomerNID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerFamily { get; set; }
        public string CustomerMobile { get; set; }
        public string? CustomerEmail { get; set; }
        public string CustomerPostalCode { get; set; }
        public string CustomerAddress { get; set; }
        public string ParcelContent { get; set; }
        public int ParcelCategoryID { get; set; }
        public PostPriceRequest Price { get; set; }
    }

    public class PostPriceRequest
    {
        public int ShopID { get; set; }
        public int ToCityID { get; set; }
        public int ServiceTypeID { get; set; }
        public int PayTypeID { get; set; }
        public int Weight { get; set; }
        public int ParcelValue { get; set; }
        public bool CollectNeed { get; set; }
        public bool NonStandardPackage { get; set; }
        public bool SMSService { get; set; }
    }
}
