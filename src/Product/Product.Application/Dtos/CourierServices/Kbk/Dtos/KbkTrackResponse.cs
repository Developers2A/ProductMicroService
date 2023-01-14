using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.Kbk.Dtos
{
    public class KbkTrackResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}