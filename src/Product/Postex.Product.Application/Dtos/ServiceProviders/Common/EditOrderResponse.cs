using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.ServiceProviders.Common
{
    public class EditOrderResponse
    {
        [JsonPropertyName("tracking_number")]
        public string TrackingNumber { get; set; }
    }
}
