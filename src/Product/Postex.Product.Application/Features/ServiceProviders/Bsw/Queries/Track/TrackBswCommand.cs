using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Bsw;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Bsw.Queries.Track
{
    public class TrackBswCommand : ITransactionRequest<BaseResponse<List<BswTrackResponseDto>>>
    {
        public string OrderNumber { get; set; }
    }
}
