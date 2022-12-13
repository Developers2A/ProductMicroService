using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.Chapar.Common
{
    public class ChaparDate
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
    }
}
