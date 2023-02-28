using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Taroff.Dtos
{
    public class TaroffDeleteResponse
    {
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
