using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Request
{
    public class LocationDto
    {
        [JsonProperty("post_code")]
        public string PostCode { get; set; }

        public string? Country { get; set; }

        [JsonProperty("city_id")]
        public int CityId { get; set; }

        [JsonProperty("city_name")]
        public string? CityName { get; set; }

        public string Address { get; set; }
        public string? Lat { get; set; }
        public string? Lon { get; set; }
    }
}
