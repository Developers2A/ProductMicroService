using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.Link
{
    public class LinkRemoveResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
