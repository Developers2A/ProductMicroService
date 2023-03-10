using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Request
{
    public class DeliveryPickupDto
    {
        public int Request { get; set; }

        [JsonProperty("date_on_utc")]
        public DateTime Date { get; set; }
    }
}
