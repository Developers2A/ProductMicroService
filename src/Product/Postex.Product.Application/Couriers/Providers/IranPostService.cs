using MediatR;
using Postex.Product.Application.Dtos.Commons.CreateOrder.Response;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Dtos.Trackings;
using Postex.Product.Application.Features.Common.Commands.CreateOrder;
using Postex.Product.Application.Features.Common.Queries.GetPrice;
using Postex.Product.Application.Features.Common.Queries.Track;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Couriers.Providers
{
    public class IranPostService : ICouierService
    {
        private readonly IMediator _mediator;

        public IranPostService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public CourierCode Courier { get; set; }

        public Task<BaseResponse<CreateParcelResponseDto>> CreateParcel(CreateParcelCommand request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<GetPriceResponse>> GetPrice(GetPriceQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<TrackingMapResponse>> TrackParcel(GetTrackQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
