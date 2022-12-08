using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Chapar;

namespace Product.Application.Features.CourierServices.Chapar.Queries.OrderTrack
{
    public class GetChaparTrackQuery : ITransactionRequest<BaseResponse<ChaparTrackResponse>>
    {
        [JsonProperty("order")]
        public ChaparOrderTracking Order { get; set; }
    }

    public class ChaparOrderTracking
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; } = "fa";
    }
}
