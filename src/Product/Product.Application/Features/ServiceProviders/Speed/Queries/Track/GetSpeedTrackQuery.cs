using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Speed.Dtos;

namespace Product.Application.Features.ServiceProviders.Speed.Queries.Track
{
    public class GetSpeedTrackQuery : ITransactionRequest<BaseResponse<SpeedTrackResponse>>
    {
        public long Barcode { get; set; }
    }
}
