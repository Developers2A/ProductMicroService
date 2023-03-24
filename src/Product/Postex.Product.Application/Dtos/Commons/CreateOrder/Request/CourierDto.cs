using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Request
{
    public class CourierDto
    {
        [JsonPropertyName("service_type")]
        public int ServiceType { get; set; }

        [JsonPropertyName("payment_type")]
        public int PaymentType { get; set; }
    }
}
