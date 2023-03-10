using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Response
{
    public class ShipmentResponseDto
    {
        [JsonProperty("step")]
        public int Step { get; set; }

        [JsonProperty("courier")]
        public CourierResponseDto Courier { get; set; }

        [JsonProperty("tracking")]
        public TrackingResponseDto Tracking { get; set; }

        [JsonProperty("shipping_rate")]
        public ShippingRateResponseDto ShippingRate { get; set; }
    }
}
