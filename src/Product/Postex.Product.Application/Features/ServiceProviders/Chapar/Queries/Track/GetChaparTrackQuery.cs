using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Chapar;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Chapar.Queries.Track
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
