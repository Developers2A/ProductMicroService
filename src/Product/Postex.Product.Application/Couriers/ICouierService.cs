using Postex.Product.Application.Dtos.Commons.CreateParcel.Response;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Dtos.Trackings;
using Postex.Product.Application.Features.Common.Commands.CreateParcel;
using Postex.Product.Application.Features.Common.Queries.GetPrice;
using Postex.Product.Application.Features.Common.Queries.Track;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Couriers
{
    public interface ICouierService
    {
        CourierCode Courier { get; set; }
        Task<BaseResponse<GetPriceResponse>> GetPrice(GetPriceQuery request);
        Task<BaseResponse<ParcelResponseDto>> CreateParcel(CreateParcelCommand request);
        Task<BaseResponse<TrackResponseDto>> TrackParcel(GetTrackQuery request);
    }
}
