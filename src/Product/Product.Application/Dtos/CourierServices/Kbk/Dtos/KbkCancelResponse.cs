using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.Kbk.Dtos
{
    public class KbkCancelResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("shipment_code")]
        public string ShipmentCode { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
