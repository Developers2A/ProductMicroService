using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Response
{
    public class AdditionalDataResponseDto
    {
        [JsonProperty("generated_postcode")]
        public string? GeneratedPostCode { get; set; }
    }
}
