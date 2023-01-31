using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.PishroPost
{
    public class PishroPostCancelOrderRequest
    {
        [JsonProperty("consignment_no")]
        public string ConsignmentNo { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
