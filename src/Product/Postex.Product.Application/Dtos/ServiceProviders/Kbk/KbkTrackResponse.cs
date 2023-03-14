using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Kbk
{
    public class KbkTrackResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}