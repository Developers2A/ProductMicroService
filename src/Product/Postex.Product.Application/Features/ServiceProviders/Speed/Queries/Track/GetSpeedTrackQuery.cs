using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Speed.Dtos;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Speed.Queries.Track
{
    public class GetSpeedTrackQuery : ITransactionRequest<BaseResponse<SpeedTrackResponse>>
    {
        public long Barcode { get; set; }
    }
}
