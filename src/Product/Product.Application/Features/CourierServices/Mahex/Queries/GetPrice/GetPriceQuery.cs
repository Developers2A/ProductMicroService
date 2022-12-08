using Newtonsoft.Json;
using Product.Application.Contracts;
using Product.Application.Dtos.Mahex.Common;

namespace Product.Application.Features.CourierServices.Mahex.Queries.GetPrice
{
    public class GetPriceQuery : ITransactionRequest<string>
    {
        [JsonProperty("from_address")]
        public MahexAddress FromAddress { get; set; }

        [JsonProperty("to_address")]
        public MahexAddress ToAddress { get; set; }

        [JsonProperty("parcels")]
        public List<MahexGetPriceParcel> Parcels { get; set; }

        [JsonProperty("package_type")]
        public string PackageType { get; set; }

        [JsonProperty("declared_value")]
        public string DeclaredValue { get; set; }
    }
}
