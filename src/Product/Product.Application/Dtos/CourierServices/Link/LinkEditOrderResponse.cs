using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.Link
{
    public class LinkEditOrderResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("tracking_code")]
        public string TrackingCode { get; set; }
    }
}
