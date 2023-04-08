using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.CreateParcel.Response
{
    public class TrackingResponseDto
    {
        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }

        [JsonPropertyName("tracking_number")]
        public string TrackingNumber { get; set; }
    }
}
