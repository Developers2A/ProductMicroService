using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Mahex.Common
{
    public class MahexAddress
    {
        [JsonProperty("city_code")]
        public string CityCode { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        public string Street { get; set; }
    }
}
