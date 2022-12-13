using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Bsw;

namespace Product.Application.Features.CourierServices.Bsw.Queries.Track
{
    public class TrackBswCommand : ITransactionRequest<BaseResponse<List<BswTrackResponseDto>>>
    {
        public string OrderNumber { get; set; }
    }
}
