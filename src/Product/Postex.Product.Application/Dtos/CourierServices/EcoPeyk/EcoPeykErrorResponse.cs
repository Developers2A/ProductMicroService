using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.EcoPeyk
{
    public class EcoPeykErrorResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("errors")]
        public EcoPeykError Errors { get; set; }
    }

    public class EcoPeykError
    {
    }
}
