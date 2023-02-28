using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Chapar.Common
{
    public class ChaparUser
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
