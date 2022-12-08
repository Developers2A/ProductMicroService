using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Trackings;

namespace Product.Application.Features.Tracks.Queries.Track
{
    public class GetTrackQuery : ITransactionRequest<BaseResponse<TrackingMapResponse>>
    {
        public string Courier { get; set; }
        public string TrackingCode { get; set; }
    }
}
