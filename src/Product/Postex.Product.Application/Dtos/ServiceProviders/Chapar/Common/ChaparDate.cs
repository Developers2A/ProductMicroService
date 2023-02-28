using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Chapar.Common
{
    public class ChaparDate
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
    }
}
