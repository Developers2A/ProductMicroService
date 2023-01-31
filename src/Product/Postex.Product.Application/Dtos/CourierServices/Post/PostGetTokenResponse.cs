using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.Post
{
    public class PostGetTokenResponse
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }
    }
}
