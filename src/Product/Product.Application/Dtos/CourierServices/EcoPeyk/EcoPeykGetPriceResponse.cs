using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.EcoPeyk
{
    public class EcoPeykGetPriceResponse
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
