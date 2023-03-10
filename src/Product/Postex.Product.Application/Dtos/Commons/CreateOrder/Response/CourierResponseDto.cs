using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Response
{
    public class CourierResponseDto
    {
        [JsonProperty("courier")]
        public string Courier { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("transit_time")]
        public string TransitTime { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
