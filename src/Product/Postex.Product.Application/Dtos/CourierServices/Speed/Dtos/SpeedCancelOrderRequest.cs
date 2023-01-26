using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.Speed.Dtos
{
    public class SpeedCancelOrderRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("barcode")]
        public long Barcode { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (Barcode <= 0)
            {
                status = false;
                message = "Barcode is required. Barcode must be greater than zero";

            }
            return (status, message);
        }
    }
}