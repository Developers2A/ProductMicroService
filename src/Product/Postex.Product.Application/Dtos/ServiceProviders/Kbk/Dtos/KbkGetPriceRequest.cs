using Newtonsoft.Json;
using System.Collections.Generic;

namespace Postex.Product.Application.Dtos.ServiceProviders.Kbk.Dtos
{
    public class KbkGetPriceRequest
    {
        [JsonProperty("apiCode")]
        public string ApiCode { get; set; }

        [JsonProperty("originCity")]
        public int OriginCity { get; set; }

        [JsonProperty("destinationCity")]
        public int DestinationCity { get; set; }

        [JsonProperty("packetsDetail")]
        public List<KbkPriceDetailsRequest> Detail { get; set; }
    }

    public class KbkPriceDetailsRequest
    {
        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
