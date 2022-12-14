using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.PishroPost;

namespace Product.Application.Features.ServiceProviders.PishroPost.Queries.Track
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
