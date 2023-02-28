using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Kbk.Dtos
{
    public class KbkCreateOrderResponse
    {
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("shipment_id")]
        public string ShipmentId { get; set; }

        [JsonProperty("shipment_code")]
        public string ShipmentCode { get; set; }

        [JsonProperty("final_price")]
        public string FinalPrice { get; set; }

        [JsonProperty("PrintAddress")]
        public string print_address { get; set; }
    }
}
