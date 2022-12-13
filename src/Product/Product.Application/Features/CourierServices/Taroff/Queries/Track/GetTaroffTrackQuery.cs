using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Taroff.Dtos;

namespace Product.Application.Features.CourierServices.Taroff.Queries.Track
{
    public class GetTaroffTrackQuery : ITransactionRequest<BaseResponse<TaroffTrackResponse>>
    {
        public string Token { get; set; }
        public int OrderId { get; set; }
    }
}
