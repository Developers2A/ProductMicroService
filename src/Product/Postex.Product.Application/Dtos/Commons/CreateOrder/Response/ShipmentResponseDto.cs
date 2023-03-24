using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Response
{
    public class ShipmentResponseDto
    {
        [JsonPropertyName("step")]
        public int Step { get; set; }

        [JsonPropertyName("courier")]
        public CourierResponseDto Courier { get; set; }

        [JsonPropertyName("tracking")]
        public TrackingResponseDto Tracking { get; set; }

        [JsonPropertyName("shipping_rate")]
        public ShippingRateResponseDto ShippingRate { get; set; }
    }
}
