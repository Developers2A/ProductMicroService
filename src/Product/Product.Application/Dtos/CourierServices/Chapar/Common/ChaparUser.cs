using Newtonsoft.Json;

namespace Product.Application.Dtos.Chapar.Common
{
    public class ChaparUser
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
