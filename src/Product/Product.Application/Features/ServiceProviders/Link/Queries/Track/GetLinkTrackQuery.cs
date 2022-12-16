using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Link;

namespace Product.Application.Features.ServiceProviders.Link.Queries.Track
{
    public class GetLinkTrackQuery : ITransactionRequest<BaseResponse<LinkTrackResponse>>
    {
        [JsonProperty("trackingCode")]
        public string TrackingCode { get; set; }
    }
}
