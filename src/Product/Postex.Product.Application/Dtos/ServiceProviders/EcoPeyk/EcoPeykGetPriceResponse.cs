using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.EcoPeyk
{
    public class EcoPeykGetPriceResponse
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
