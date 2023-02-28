using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Mahex.Common
{
    public class MahexOrderData
    {
        [JsonProperty("shipment_uuid")]
        public string ShipmentUuid { get; set; }
    }
}
