using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.GetPrice.Request
{
    public class CourierInfoDto
    {
        [JsonPropertyName("courier_code")]
        public int CourierCode { get; set; }

        [JsonPropertyName("service_type")]
        public int ServiceType { get; set; }

        [JsonPropertyName("payment_type")]
        public int PaymentType { get; set; }
    }
}
