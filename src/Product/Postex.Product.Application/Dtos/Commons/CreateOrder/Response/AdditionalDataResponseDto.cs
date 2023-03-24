using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Response
{
    public class AdditionalDataResponseDto
    {
        [JsonPropertyName("generated_postcode")]
        public string? GeneratedPostCode { get; set; }
    }
}
