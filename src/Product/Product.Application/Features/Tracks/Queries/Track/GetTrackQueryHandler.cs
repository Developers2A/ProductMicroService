using MediatR;
using Postex.SharedKernel.Common;
using Product.Application.Dtos.Trackings;
using Product.Application.Features.CourierServices.Chapar.Queries.OrderTrack;
using Product.Application.Features.CourierServices.Mahex.Queries.OrderTrack;
using Product.Application.Features.CourierServices.Post.Queries.OrderTrack;
using Product.Application.Features.CourierStatusMappings.Queries;
using Product.Domain.Enums;
using ProductService.Application.Dtos.Couriers;

namespace Product.Application.Features.Tracks.Queries.Track
{
    public class GetTrackQueryHandler : IRequestHandler<GetTrackQuery, BaseResponse<TrackingMapResponse>>
    {
        private readonly IMediator _mediator;

        public GetTrackQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<TrackingMapResponse>> Handle(GetTrackQuery request, CancellationToken cancellationToken)
        {
            if (request.Courier == CourierConstants.POST)
            {
                var result = await _mediator.Send(new GetPostTrackQuery()
                {
                    ParcelCode = request.TrackingCode
                });
            }

            if (request.Courier == CourierConstants.CHAPAR)
            {
                return await MapToChapar(request);
            }

            if (request.Courier == CourierConstants.MAHEX)
            {
                return await MapToMahex(request);
            }

            return new BaseResponse<TrackingMapResponse>();
        }

        public async Task<BaseResponse<TrackingMapResponse>> MapToChapar(GetTrackQuery request)
        {
            var trackRequest = new GetChaparTrackQuery()
            {
                Order = new()
                {
                    Reference = request.TrackingCode,
                    Lang = "fa"
                }
            };
            var result = await _mediator.Send(trackRequest);
            if (!result.IsSuccess)
            {
                return new(false, result.Message);
            }

            var status = result.Data.Objects.Order.History.FirstOrDefault().Status;
            var timestamp = result.Data.Objects.Order.History.FirstOrDefault().Timestamp_Date;
            var date = DateTimeOffset.FromUnixTimeSeconds(timestamp).LocalDateTime;

            var finalStatus = status.Split(" ")[0];

            var tracking = await GetPostexStatus(CourierCode.Chapar, finalStatus);
            if (tracking == null)
            {
                return new(false, "Chapar Mappping is not set in database");
            }

            return new(true, "success", new TrackingMapResponse()
            {
                CourierStatusMappingId = tracking.Id,
                TrackingCode = tracking.Code.ToString(),
                TrackingStatusNote = tracking.Name,
                CourierStatus = tracking.Description,
                Date = date.ToString()
            });

        }

        private async Task<CourierStatusMappingDto> GetPostexStatus(CourierCode courierCode, string courierStatus)
        {
            var courierStatusMapping = await _mediator.Send(new GetCourierStatusMappingByCourierAndStatusQuery()
            {
                Courier = courierCode,
                CourierStatus = courierStatus
            });
            return courierStatusMapping;
        }

        public async Task<BaseResponse<TrackingMapResponse>> MapToMahex(GetTrackQuery request)
        {
            var trackRequest = new GetMahexTrackQuery()
            {
                PartNumber = request.TrackingCode
            };

            var result = await _mediator.Send(trackRequest);
            if (!result.IsSuccess)
            {
                trackRequest = new GetMahexTrackQuery()
                {
                    WaybillNumber = request.TrackingCode
                };
                result = await _mediator.Send(trackRequest);
                if (!result.IsSuccess)
                {
                    trackRequest = new GetMahexTrackQuery()
                    {
                        Reference = request.TrackingCode
                    };
                    result = await _mediator.Send(trackRequest);
                }
            }
            if (result.IsSuccess)
            {
                var status = result.Data.Data.CurrentState;
                var date = result.Data.Data.UpdateDate;

                var tracking = await GetPostexStatus(CourierCode.Mahex, status);
                if (tracking != null)
                {
                    return new(true, "success", new TrackingMapResponse()
                    {
                        CourierStatusMappingId = tracking.Id,
                        TrackingCode = tracking.Code.ToString(),
                        TrackingStatusNote = tracking.Name,
                        CourierStatus = tracking.Description,
                        Date = date
                    });
                }
                else
                {
                    return new(false, "Mahex Mappping is not set in database");
                }
            }
            else
            {
                return new(true, result.Message);
            }
        }

    }
}
