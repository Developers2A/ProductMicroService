using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.EcoPeyk
{
    public class EcoPeykGetTokenResponse
    {
        [JsonProperty("accessToken")]
        public string Token { get; set; }
    }
}
