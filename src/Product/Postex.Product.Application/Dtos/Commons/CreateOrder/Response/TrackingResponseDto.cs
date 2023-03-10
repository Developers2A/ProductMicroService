using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Response
{
    public class TrackingResponseDto
    {
        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("tracking_number")]
        public string TrackingNumber { get; set; }
    }
}
