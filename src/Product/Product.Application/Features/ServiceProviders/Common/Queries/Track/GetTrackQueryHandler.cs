using MediatR;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Utilities;
using Product.Application.Dtos.Couriers;
using Product.Application.Dtos.Trackings;
using Product.Application.Features.CourierServices.Chapar.Queries.Track;
using Product.Application.Features.CourierServices.Link.Queries.Track;
using Product.Application.Features.CourierServices.Mahex.Queries.Track;
using Product.Application.Features.CourierServices.PishroPost.Queries.Track;
using Product.Application.Features.CourierServices.Post.Queries.Track;
using Product.Application.Features.CourierServices.Speed.Queries.Track;
using Product.Application.Features.CourierServices.Taroff.Queries.Track;
using Product.Application.Features.CourierStatusMappings.Queries;
using Product.Domain.Enums;

namespace Product.Application.Features.ServiceProviders.Common.Queries.Track
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
            if (request.Courier == (int)CourierCode.Post)
            {
                var result = await _mediator.Send(new GetPostTrackQuery()
                {
                    ParcelCode = request.TrackingCode
                });
            }

            if (request.Courier == (int)CourierCode.Chapar)
            {
                return await MapToChapar(request);
            }

            if (request.Courier == (int)CourierCode.Mahex)
            {
                return await MapToMahex(request);
            }
            if (request.Courier == (int)CourierCode.Link)
            {
                return await MapToLink(request);
            }
            if (request.Courier == (int)CourierCode.Taroff)
            {
                return await MapToLink(request);
            }
            if (request.Courier == (int)CourierCode.PishroPost)
            {
                return await MapToPishroPost(request);
            }
            if (request.Courier == (int)CourierCode.Speed)
            {
                return await MapToSpeed(request);
            }
            return new(false, "not found");
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
            if (!result.IsSuccess)
            {
                return new(true, result.Message);
            }

            var status = result.Data.Data.CurrentState;
            var date = result.Data.Data.UpdateDate;

            var tracking = await GetPostexStatus(CourierCode.Mahex, status);
            if (tracking == null)
            {
                return new(false, "Mahex Mappping is not set in database");
            }

            return new(true, "success", new TrackingMapResponse()
            {
                CourierStatusMappingId = tracking.Id,
                TrackingCode = tracking.Code.ToString(),
                TrackingStatusNote = tracking.Name,
                CourierStatus = tracking.Description,
                Date = date
            });
        }

        public async Task<BaseResponse<TrackingMapResponse>> MapToLink(GetTrackQuery request)
        {
            var trackRequest = new GetLinkTrackQuery()
            {
                ShipmentCode = request.TrackingCode
            };

            var result = await _mediator.Send(trackRequest);
            if (!result.IsSuccess)
            {
                return new(false, result.Message);
            }

            var status = result.Data.Result.State;
            var date = result.Data.Result.DoneDate.ToString();

            var tracking = await GetPostexStatus(CourierCode.Link, status.ToString());
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
                return new(false, "Link Mappping is not set in database");
            }
        }

        public async Task<BaseResponse<TrackingMapResponse>> MapToTaroff(GetTrackQuery request)
        {
            var trackRequest = new GetTaroffTrackQuery()
            {
                OrderId = Convert.ToInt32(request.TrackingCode)
            };

            var result = await _mediator.Send(trackRequest);
            if (!result.IsSuccess)
            {
                return new(false, result.Message);
            }
            var status = result.Data.StateId;
            var date = "";

            var tracking = await GetPostexStatus(CourierCode.Taroff, status.ToString());
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
                return new(false, "Tarrof Mappping is not set in database");
            }
        }

        public async Task<BaseResponse<TrackingMapResponse>> MapToPishroPost(GetTrackQuery request)
        {
            var trackRequest = new GetPishroPostTrackQuery()
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
            var date = result.Data.Objects.Order.History.FirstOrDefault().Date;
            date = date.PersianDateStringToDateTime().ToString();

            var finalStatus = status.Split(" ")[0];

            var tracking = await GetPostexStatus(CourierCode.PishroPost, finalStatus);
            if (tracking == null)
            {
                return new(false, "Pishro Post Mappping is not set in database");
            }
            return new(true, "success", new TrackingMapResponse()
            {
                CourierStatusMappingId = tracking.Id,
                TrackingCode = tracking.Code.ToString(),
                TrackingStatusNote = tracking.Name,
                CourierStatus = tracking.Description,
                Date = date
            });
        }

        public async Task<BaseResponse<TrackingMapResponse>> MapToSpeed(GetTrackQuery request)
        {
            var trackRequest = new GetSpeedTrackQuery()
            {
                Barcode = Convert.ToInt64(request.TrackingCode)
            };

            var result = await _mediator.Send(trackRequest);
            if (!result.IsSuccess)
            {
                return new(false, result.Message);
            }
            string status = "";
            string date = "";

            for (int i = 0; i < result.Data.ResultJson.Length; i++)
            {
                if (i == result.Data.ResultJson.Length - 1)
                {
                    var item = result.Data.ResultJson[i];
                    status = item.Trim().Split("---")[1].Split("-")[0].Trim();
                    date = item.Trim().Split("---")[0].Trim().PersianDateStringToDateTime().ToString();
                }
            }

            var tracking = await GetPostexStatus(CourierCode.Speed, status);
            if (tracking == null)
            {
                return new(false, "Pishro Post Mappping is not set in database");
            }
            return new(true, "success", new TrackingMapResponse()
            {
                CourierStatusMappingId = tracking.Id,
                TrackingCode = tracking.Code.ToString(),
                TrackingStatusNote = tracking.Name,
                CourierStatus = tracking.Description,
                Date = date
            });
        }
    }
}
