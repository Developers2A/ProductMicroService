using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Trackings;
using Postex.SharedKernel.Common;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Features.Common.Queries.Track
{
    public class GetTrackQuery : ITransactionRequest<BaseResponse<TrackResponseDto>>
    {
        [JsonPropertyName("courier_code")]
        public int CourierCode { get; set; }

        [JsonPropertyName("track_code")]
        public string TrackCode { get; set; }
    }
}
