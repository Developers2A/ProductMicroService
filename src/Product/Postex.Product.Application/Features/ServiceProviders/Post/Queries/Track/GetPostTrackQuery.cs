using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Queries.Track
{
    public class GetPostTrackQuery : ITransactionRequest<BaseResponse<PostTrackResponse>>
    {
        [JsonProperty("parcelCode")]
        public string ParcelCode { get; set; }
    }
}
