using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.Kbk.Dtos
{
    public class KbkGetPriceResponse
    {
        [JsonProperty("shipment_cost")]
        public int ShipmentCost { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
