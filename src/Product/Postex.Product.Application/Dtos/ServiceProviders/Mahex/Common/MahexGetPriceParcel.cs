using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Mahex.Common
{
    public class MahexGetPriceParcel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("length")]
        public decimal Length { get; set; }

        [JsonProperty("width")]
        public decimal Width { get; set; }

        [JsonProperty("height")]
        public decimal Height { get; set; }

        [JsonProperty("weight")]
        public decimal Weight { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("package_type")]
        public string PackageType { get; set; }

        [JsonProperty("declared_value")]
        public int DeclaredValue { get; set; }
    }
}
