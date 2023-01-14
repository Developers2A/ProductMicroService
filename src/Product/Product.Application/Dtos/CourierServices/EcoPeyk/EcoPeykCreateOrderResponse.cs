using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.EcoPeyk
{
    public class EcoPeykOrderResponse
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class EcoPeykCreateOrderResponse
    {
        [JsonProperty("requestId")]
        public int RequestId { get; set; }

        [JsonProperty("orders")]
        public List<EcoPeykOrderResponse> Orders { get; set; }
    }
}
