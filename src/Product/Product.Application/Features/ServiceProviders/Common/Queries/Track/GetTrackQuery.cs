using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Trackings;

namespace Product.Application.Features.ServiceProviders.Common.Queries.Track
{
    public class GetTrackQuery : ITransactionRequest<BaseResponse<TrackingMapResponse>>
    {
        public int CourierCode { get; set; }
        public string TrackingCode { get; set; }
    }
}
