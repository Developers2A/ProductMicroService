using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.CreateParcel.Response
{
    public class AdditionalDataResponseDto
    {
        [JsonPropertyName("generated_postcode")]
        public string? GeneratedPostCode { get; set; }
    }
}
