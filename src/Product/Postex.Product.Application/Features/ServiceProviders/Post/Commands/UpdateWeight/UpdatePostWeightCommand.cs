using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Commands.UpdateWeight
{
    public class UpdatePostWeightCommand : ITransactionRequest<BaseResponse<PostEditWeightResponse>>
    {
        public int ShopID { get; set; }
        //public string SenderMobile { get; set; }
        public string ParcelCode { get; set; }
        public int Weight { get; set; }
        public long ParcelValue { get; set; }
        public bool NonStandardPackage { get; set; }
    }
}
