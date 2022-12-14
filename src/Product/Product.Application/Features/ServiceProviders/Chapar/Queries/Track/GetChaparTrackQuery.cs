using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Chapar;

namespace Product.Application.Features.ServiceProviders.Chapar.Queries.Track
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
