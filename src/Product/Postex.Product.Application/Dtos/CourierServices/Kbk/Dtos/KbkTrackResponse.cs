using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.Kbk.Dtos
{
    public class KbkTrackResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}