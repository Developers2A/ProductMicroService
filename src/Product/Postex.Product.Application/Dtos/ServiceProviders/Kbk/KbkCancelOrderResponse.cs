using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Kbk
{
    public class KbkCancelOrderResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("shipment_code")]
        public string ShipmentCode { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
