using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.Speed.Dtos
{
    public class SpeedGetPriceRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("qty")]
        public int Qty { get; set; }

        [JsonProperty("vol")]
        public int Vol { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (Weight <= 0)
            {
                status = false;
                message = "Weight must be greater than zero. ";
            }
            if (Qty <= 0)
            {
                status = false;
                message += "Qty must be greater than zero. ";
            }
            if (Vol < 0 || Vol > 1)
            {
                status = false;
                message += "Vol must be 0,1(parcel has valume). ";
            }
            if (string.IsNullOrEmpty((City ?? "").Trim()))
            {
                status = false;
                message += "City is required. ";
            }
            return (status, message);
        }
    }
}