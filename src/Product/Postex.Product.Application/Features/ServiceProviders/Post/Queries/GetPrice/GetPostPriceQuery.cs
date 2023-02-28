using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetPrice
{
    public class GetPostPriceQuery : ITransactionRequest<BaseResponse<PostGetPriceResponse>>
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
