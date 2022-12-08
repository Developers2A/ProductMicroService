using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Post;

namespace Product.Application.Features.CourierServices.Post.Queries.OrderTrack
{
    public class GetPostTrackQuery : ITransactionRequest<BaseResponse<PostTrackResponse>>
    {
        [JsonProperty("parcelCode")]
        public string ParcelCode { get; set; }
    }
}
