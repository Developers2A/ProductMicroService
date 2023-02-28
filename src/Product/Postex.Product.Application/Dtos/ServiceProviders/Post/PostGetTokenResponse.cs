using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Post
{
    public class PostGetTokenResponse
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }
    }
}
