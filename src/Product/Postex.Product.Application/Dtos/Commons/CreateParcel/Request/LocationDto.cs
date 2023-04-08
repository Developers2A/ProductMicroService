using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.CreateParcel.Request
{
    public class LocationDto
    {
        [JsonPropertyName("post_code")]
        public string PostCode { get; set; }

        public string? Country { get; set; }

        [JsonPropertyName("city_code")]
        public int CityCode { get; set; }

        [JsonPropertyName("city_name")]
        public string? CityName { get; set; }

        public string Address { get; set; }
        public string? Lat { get; set; }
        public string? Lon { get; set; }
    }
}
