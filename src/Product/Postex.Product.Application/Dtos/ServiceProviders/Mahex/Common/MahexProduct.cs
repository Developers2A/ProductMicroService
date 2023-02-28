using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Mahex.Common
{
    public class MahexProduct
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

    }
}
