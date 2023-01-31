using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Kbk.Dtos;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Kbk.Queries.GetPrice
{
    public class GetKbkPriceQuery : ITransactionRequest<BaseResponse<KbkGetPriceResponse>>
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
