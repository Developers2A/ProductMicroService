using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Post;

namespace Product.Application.Features.ServiceProviders.Post.Queries.Track
{
    public class GetPostTrackQuery : ITransactionRequest<BaseResponse<PostTrackResponse>>
    {
        [JsonProperty("parcelCode")]
        public string ParcelCode { get; set; }
    }
}
