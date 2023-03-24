using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Response
{
    public class CourierResponseDto
    {
        [JsonPropertyName("courier")]
        public string Courier { get; set; }

        [JsonPropertyName("service")]
        public string Service { get; set; }

        [JsonPropertyName("transit_time")]
        public string TransitTime { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
