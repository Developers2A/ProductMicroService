using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.Taroff.Dtos
{
    public class TaroffDeleteRequest
    {
        public string Token { get; set; }

        [JsonProperty("orderId")]
        public int OrderId { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (OrderId <= 0)
            {
                return new(false, "OrderId must be greater than zero.");
            }
            return (status, message);
        }
    }
}
