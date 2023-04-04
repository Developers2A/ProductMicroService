using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.GetPrice.Request
{
    public class SenderReceiverInfoDto
    {
        [JsonPropertyName("province_code")]
        public int ProvinceCode { get; set; }

        [JsonPropertyName("city_code")]
        public int CityCode { get; set; }
    }
}
