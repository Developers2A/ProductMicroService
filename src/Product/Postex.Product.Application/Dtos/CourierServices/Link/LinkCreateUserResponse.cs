using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.Link
{
    public class LinkCreateUserResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("accountGuid")]
        public string AccountGuid { get; set; }
    }
}
