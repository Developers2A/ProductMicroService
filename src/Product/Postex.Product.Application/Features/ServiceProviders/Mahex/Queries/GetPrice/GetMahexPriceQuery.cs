using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Mahex;
using Postex.Product.Application.Dtos.CourierServices.Mahex.Common;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Mahex.Queries.GetPrice
{
    public class GetMahexPriceQuery : ITransactionRequest<BaseResponse<MahexGetPriceResponse>>
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
