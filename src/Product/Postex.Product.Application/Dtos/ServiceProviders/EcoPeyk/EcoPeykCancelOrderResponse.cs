using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.EcoPeyk
{
    public class EcoPeykCancelOrderResponse
    {
        [JsonProperty("requestId")]
        public int RequestId { get; set; }
    }
}
