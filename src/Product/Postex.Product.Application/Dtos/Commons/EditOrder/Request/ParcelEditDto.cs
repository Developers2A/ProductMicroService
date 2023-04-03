using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.EditOrder.Request
{
    public class ParcelEditDto
    {
        [JsonPropertyName("parcel_code")]
        public string ParcelCode { get; set; }

        [JsonPropertyName("item_name")]
        public string ItemName { get; set; }
    }
}
