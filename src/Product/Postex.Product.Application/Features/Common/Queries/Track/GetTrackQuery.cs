using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Trackings;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Queries.Track
{
    public class GetTrackQuery : ITransactionRequest<BaseResponse<TrackingMapResponse>>
    {
        public int CourierCode { get; set; }
        public string TrackCode { get; set; }
    }
}
