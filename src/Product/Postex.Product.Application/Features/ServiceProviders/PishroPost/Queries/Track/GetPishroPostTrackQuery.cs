using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.PishroPost;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.PishroPost.Queries.Track
{
    public class GetPishroPostTrackQuery : ITransactionRequest<BaseResponse<PishroPostTrackResponse>>
    {
        [JsonProperty("order")]
        public PishroPostOrderTracking Order { get; set; }
    }

    public class PishroPostOrderTracking
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; } = "fa";
    }
}
