using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Request
{
    public class ParcelDto
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        [JsonProperty("total_weight")]
        public int TotalWeight { get; set; }

        [JsonProperty("is_fragile")]
        public bool IsFragile { get; set; }

        [JsonProperty("is_liquid")]
        public bool IsLiquid { get; set; }

        [JsonProperty("total_value")]
        public int TotalValue { get; set; }

        [JsonProperty("item_name")]
        public string ItemName { get; set; }
    }
}
