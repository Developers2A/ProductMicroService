using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.CreateParcel.Response
{
    public class AdditionalDataResponseDto
    {
        // کد پستی جایگزین شده
        [JsonPropertyName("generated_postcode")]
        public string? GeneratedPostCode { get; set; }
    }
}
