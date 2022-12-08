using Newtonsoft.Json;

namespace Product.Application.Dtos.Post
{
    public class PostGetTokenResponse
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }
    }
}
