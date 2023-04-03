using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.GetPrice.Request
{
    public class ParcelInfoDto
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public int BoxTypeId { get; set; }

        [JsonPropertyName("total_weight")]
        public int TotalWeight { get; set; }

        [JsonPropertyName("total_value")]
        public int TotalValue { get; set; }
    }
}
