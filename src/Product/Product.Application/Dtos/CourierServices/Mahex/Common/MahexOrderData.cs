using Newtonsoft.Json;

namespace Product.Application.Dtos.Mahex.Common
{
    public class MahexOrderData
    {
        [JsonProperty("shipment_uuid")]
        public string ShipmentUuid { get; set; }
    }
}
