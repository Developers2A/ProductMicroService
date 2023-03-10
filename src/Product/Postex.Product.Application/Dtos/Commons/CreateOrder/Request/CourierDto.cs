using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Request
{
    public class CourierDto
    {
        [JsonProperty("service_type")]
        public int ServiceType { get; set; }

        [JsonProperty("payment_type")]
        public int PaymentType { get; set; }
    }
}
