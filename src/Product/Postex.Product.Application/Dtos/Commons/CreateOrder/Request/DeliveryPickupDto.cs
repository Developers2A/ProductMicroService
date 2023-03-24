using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Request
{
    public class DeliveryPickupDto
    {
        public int Request { get; set; }

        [JsonPropertyName("date_on_utc")]
        public DateTime Date { get; set; }
    }
}
