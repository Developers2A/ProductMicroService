using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.PishroPost;

namespace Product.Application.Features.ServiceProviders.PishroPost.Commands.CancelOrder
{
    public class CancelPishroPostOrderCommand : ITransactionRequest<BaseResponse<PishroPostCancelOrderResponse>>
    {
        [JsonProperty("consignment_no")]
        public string ConsignmentNo { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
