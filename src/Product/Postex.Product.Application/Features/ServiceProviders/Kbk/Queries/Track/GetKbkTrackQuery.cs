using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Kbk.Dtos;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Kbk.Queries.Track
{
    public class GetKbkTrackQuery : ITransactionRequest<BaseResponse<KbkTrackResponse>>
    {
        [JsonProperty("apiCode")]
        public string ApiCode { get; set; }

        [JsonProperty("shipmentCode")]
        public string ShipmentCode { get; set; }
    }
}
