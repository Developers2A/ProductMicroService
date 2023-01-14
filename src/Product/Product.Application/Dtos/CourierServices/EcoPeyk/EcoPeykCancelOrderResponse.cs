using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.EcoPeyk
{
    public class EcoPeykCancelOrderResponse
    {
        [JsonProperty("requestId")]
        public int RequestId { get; set; }
    }
}
