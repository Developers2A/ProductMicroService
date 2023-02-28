using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.EcoPeyk
{
    public class EcoPeykGetTokenResponse
    {
        [JsonProperty("accessToken")]
        public string Token { get; set; }
    }
}
