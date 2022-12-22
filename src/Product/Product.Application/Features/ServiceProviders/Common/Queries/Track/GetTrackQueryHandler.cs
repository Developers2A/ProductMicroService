using MediatR;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Utilities;
using Product.Application.Dtos.Couriers;
using Product.Application.Dtos.Trackings;
using Product.Application.Features.CourierStatusMappings.Queries;
using Product.Application.Features.ServiceProviders.Chapar.Queries.Track;
using Product.Application.Features.ServiceProviders.Link.Queries.Track;
using Product.Application.Features.ServiceProviders.Mahex.Queries.Track;
using Product.Application.Features.ServiceProviders.PishroPost.Queries.Track;
using Product.Application.Features.ServiceProviders.Post.Queries.Track;
using Product.Application.Features.ServiceProviders.Speed.Queries.Track;
using Product.Application.Features.ServiceProviders.Taroff.Queries.Track;
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
            if (request.CourierCode == (int)CourierCode.Post)
            {
                var result = await _mediator.Send(new GetPostTrackQuery()
                {
                    ParcelCode = request.TrackCode
                });
            }

            if (request.CourierCode == (int)CourierCode.Chapar)
            {
                return await ChaparTrack(request);
            }

            if (request.CourierCode == (int)CourierCode.Mahex)
            {
                return await MahexTrack(request);
            }
            if (request.CourierCode == (int)CourierCode.Link)
            {
                return await LinkTrack(request);
            }
            if (request.CourierCode == (int)CourierCode.Taroff)
            {
                return await TaroffTrack(request);
            }
            if (request.CourierCode == (int)CourierCode.PishroPost)
            {
                return await PishroPostTrack(request);
            }
            if (request.CourierCode == (int)CourierCode.Speed)
            {
                return await SpeedTrack(request);
            }
            return new(false, "not found");
        }

        public async Task<BaseResponse<TrackingMapResponse>> ChaparTrack(GetTrackQuery request)
        {
            var trackRequest = new GetChaparTrackQuery()
            {
                Order = new()
                {
                    Reference = request.TrackCode,
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

        public async Task<BaseResponse<TrackingMapResponse>> MahexTrack(GetTrackQuery request)
        {
            var trackRequest = new GetMahexTrackQuery()
            {
                PartNumber = request.TrackCode
            };

            var result = await _mediator.Send(trackRequest);
            if (!result.IsSuccess)
            {
                trackRequest = new GetMahexTrackQuery()
                {
                    WaybillNumber = request.TrackCode
                };
                result = await _mediator.Send(trackRequest);
                if (!result.IsSuccess)
                {
                    trackRequest = new GetMahexTrackQuery()
                    {
                        Reference = request.TrackCode
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

        public async Task<BaseResponse<TrackingMapResponse>> LinkTrack(GetTrackQuery request)
        {
            var trackRequest = new GetLinkTrackQuery()
            {
                TrackingCode = request.TrackCode
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

        public async Task<BaseResponse<TrackingMapResponse>> TaroffTrack(GetTrackQuery request)
        {
            var trackRequest = new GetTaroffTrackQuery()
            {
                OrderId = Convert.ToInt32(request.TrackCode)
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

        public async Task<BaseResponse<TrackingMapResponse>> PishroPostTrack(GetTrackQuery request)
        {
            var trackRequest = new GetPishroPostTrackQuery()
            {
                Order = new()
                {
                    Reference = request.TrackCode,
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

        public async Task<BaseResponse<TrackingMapResponse>> SpeedTrack(GetTrackQuery request)
        {
            var trackRequest = new GetSpeedTrackQuery()
            {
                Barcode = Convert.ToInt64(request.TrackCode)
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
                return new(false, "Speed Mappping is not set in database");
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
