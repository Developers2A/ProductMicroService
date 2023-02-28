using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.PishroPost;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.PishroPost.Commands.CancelOrder
{
    public class CancelPishroPostOrderCommand : ITransactionRequest<BaseResponse<PishroPostCancelOrderResponse>>
    {
        [JsonProperty("consignment_no")]
        public string ConsignmentNo { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
