using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.EditOrder.Request
{
    public class LocationEditDto
    {
        [JsonPropertyName("post_code")]
        public string PostCode { get; set; }

        public string Address { get; set; }
    }
}
