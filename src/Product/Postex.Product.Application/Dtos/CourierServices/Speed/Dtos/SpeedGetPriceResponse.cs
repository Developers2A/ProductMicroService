using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.Speed.Dtos
{
    public class SpeedGetPriceResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }
    }
}
