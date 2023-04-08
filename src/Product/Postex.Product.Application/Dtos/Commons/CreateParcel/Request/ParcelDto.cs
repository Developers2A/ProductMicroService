using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.CreateParcel.Request
{
    public class ParcelDto
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        [JsonPropertyName("total_weight")]
        public int TotalWeight { get; set; }

        [JsonPropertyName("is_fragile")]
        public bool IsFragile { get; set; }

        [JsonPropertyName("is_liquid")]
        public bool IsLiquid { get; set; }

        [JsonPropertyName("total_value")]
        public int TotalValue { get; set; }

        [JsonPropertyName("item_name")]
        public string ItemName { get; set; }
    }
}
