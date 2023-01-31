using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Link;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Link.Queries.Track
{
    public class GetLinkTrackQuery : ITransactionRequest<BaseResponse<LinkTrackResponse>>
    {
        [JsonProperty("trackingCode")]
        public string TrackingCode { get; set; }
    }
}
