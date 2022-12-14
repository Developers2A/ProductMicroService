using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Kbk.Dtos;

namespace Product.Application.Features.ServiceProviders.Kbk.Queries.Track
{
    public class GetKbkTrackQuery : ITransactionRequest<BaseResponse<KbkTrackResponse>>
    {
        [JsonProperty("apiCode")]
        public string ApiCode { get; set; }
        public string ShipmentCode { get; set; }
    }
}
