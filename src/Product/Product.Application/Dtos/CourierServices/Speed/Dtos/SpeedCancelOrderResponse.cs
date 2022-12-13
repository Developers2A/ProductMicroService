using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.Speed.Dtos
{
    public class SpeedCancelOrderResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

    }
}
