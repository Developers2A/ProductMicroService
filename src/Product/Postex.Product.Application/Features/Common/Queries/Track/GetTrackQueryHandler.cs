using MediatR;
using Postex.Product.Application.Dtos.CourierStatus;
using Postex.Product.Application.Dtos.Trackings;
using Postex.Product.Application.Features.CourierStatusMappings.Queries;
using Postex.Product.Application.Features.ServiceProviders.Chapar.Queries.Track;
using Postex.Product.Application.Features.ServiceProviders.EcoPeyk.Queries.GetStatus;
using Postex.Product.Application.Features.ServiceProviders.Kbk.Queries.Track;
using Postex.Product.Application.Features.ServiceProviders.Link.Queries.Track;
using Postex.Product.Application.Features.ServiceProviders.Mahex.Queries.Track;
using Postex.Product.Application.Features.ServiceProviders.PishroPost.Queries.Track;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetStatus;
using Postex.Product.Application.Features.ServiceProviders.Speed.Queries.Track;
using Postex.Product.Application.Features.ServiceProviders.Taroff.Queries.Track;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Utilities;

namespace Postex.Product.Application.Features.Common.Queries.Track
{
    public class GetTrackQueryHandler : IRequestHandler<GetTrackQuery, BaseResponse<TrackingMapResponse>>
    {
        private readonly IMediator _mediator;
        private GetTrackQuery _query;

        public GetTrackQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<TrackingMapResponse>> Handle(GetTrackQuery query, CancellationToken cancellationToken)
        {
            _query = query;
            if (_query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Post)
            {
                return await PostTrack();
            }
            if (_query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Chapar)
            {
                return await ChaparTrack();
            }
            if (_query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Mahex)
            {
                return await MahexTrack();
            }
            if (_query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Kalaresan)
            {
                return await KbkTrack();
            }
            if (_query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Link)
            {
                return await LinkTrack();
            }
            if (_query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Taroff)
            {
                return await TaroffTrack();
            }
            if (_query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.PishroPost)
            {
                return await PishroPostTrack();
            }
            if (_query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Speed)
            {
                return await SpeedTrack();
            }
            if (_query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.EcoPeyk)
            {
                return await EcoPeykTrack();
            }
            return new(false, "امکان ترک کدهای این کوریر وجود ندارد");
        }

        public async Task<BaseResponse<TrackingMapResponse>> PostTrack()
        {
            var trackRequest = new GetPostStatusQuery()
            {
                ParcelCodes = new List<string> { _query.TrackCode }
            };
            var result = await _mediator.Send(trackRequest);
            if (!result.IsSuccess)
            {
                return new(false, result.Message);
            }

            var status = result.Data.FirstOrDefault().ParcelStatusID;
            var date = result.Data.FirstOrDefault().UpdateDateTime;

            var tracking = await GetPostexStatus(SharedKernel.Common.Enums.CourierCode.Post, status.ToString());
            if (tracking == null)
            {
                return new(false, "Post Mappping is not set in database");
            }

            return new(true, "success", new TrackingMapResponse()
            {
                CourierStatusMappingId = tracking.Id,
                TrackCode = tracking.Code.ToString(),
                TrackStatus = tracking.Name,
                CourierStatus = tracking.Description,
                Date = date.ToString()
            });
        }

        public async Task<BaseResponse<TrackingMapResponse>> ChaparTrack()
        {
            var trackRequest = new GetChaparTrackQuery()
            {
                Order = new()
                {
                    Reference = _query.TrackCode,
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

            var tracking = await GetPostexStatus(SharedKernel.Common.Enums.CourierCode.Chapar, finalStatus);
            if (tracking == null)
            {
                return new(false, "Chapar Mappping is not set in database");
            }

            return new(true, "success", new TrackingMapResponse()
            {
                CourierStatusMappingId = tracking.Id,
                TrackCode = tracking.Code.ToString(),
                TrackStatus = tracking.Name,
                CourierStatus = tracking.Description,
                Date = date.ToString()
            });

        }

        private async Task<CourierStatusMappingDto> GetPostexStatus(SharedKernel.Common.Enums.CourierCode courierCode, string courierStatus)
        {
            var courierStatusMapping = await _mediator.Send(new GetCourierStatusMappingByCourierAndStatusQuery()
            {
                Courier = courierCode,
                CourierStatus = courierStatus
            });
            return courierStatusMapping;
        }

        public async Task<BaseResponse<TrackingMapResponse>> MahexTrack()
        {
            var trackRequest = new GetMahexTrackQuery()
            {
                PartNumber = _query.TrackCode
            };

            var result = await _mediator.Send(trackRequest);
            if (!result.IsSuccess)
            {
                trackRequest = new GetMahexTrackQuery()
                {
                    WaybillNumber = _query.TrackCode
                };
                result = await _mediator.Send(trackRequest);
                if (!result.IsSuccess)
                {
                    trackRequest = new GetMahexTrackQuery()
                    {
                        Reference = _query.TrackCode
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

            var tracking = await GetPostexStatus(SharedKernel.Common.Enums.CourierCode.Mahex, status);
            if (tracking == null)
            {
                return new(false, "Mahex Mappping is not set in database : " + status);
            }

            return new(true, "success", new TrackingMapResponse()
            {
                CourierStatusMappingId = tracking.Id,
                TrackCode = tracking.Code.ToString(),
                TrackStatus = tracking.Name,
                CourierStatus = tracking.Description,
                Date = date
            });
        }

        public async Task<BaseResponse<TrackingMapResponse>> KbkTrack()
        {
            var trackRequest = new GetKbkTrackQuery()
            {
                ShipmentCode = _query.TrackCode
            };
            var result = await _mediator.Send(trackRequest);
            if (!result.IsSuccess)
            {
                return new(false, result.Message);
            }

            var status = result.Data.Status;
            var date = "";

            var tracking = await GetPostexStatus(SharedKernel.Common.Enums.CourierCode.Kalaresan, status.ToString());
            if (tracking == null)
            {
                return new(false, "Kbk Mappping is not set in database for kbk status :" + status);
            }

            return new(true, "success", new TrackingMapResponse()
            {
                CourierStatusMappingId = tracking.Id,
                TrackCode = tracking.Code.ToString(),
                TrackStatus = tracking.Name,
                CourierStatus = tracking.Description,
                Date = date.ToString()
            });
        }


        public async Task<BaseResponse<TrackingMapResponse>> LinkTrack()
        {
            var trackRequest = new GetLinkTrackQuery()
            {
                TrackingCode = _query.TrackCode
            };

            var result = await _mediator.Send(trackRequest);
            if (!result.IsSuccess)
            {
                return new(false, result.Message);
            }

            var status = result.Data.Result.State;
            var date = result.Data.Result.DoneDate.ToString();

            var tracking = await GetPostexStatus(SharedKernel.Common.Enums.CourierCode.Link, status.ToString());
            if (tracking != null)
            {
                return new(true, "success", new TrackingMapResponse()
                {
                    CourierStatusMappingId = tracking.Id,
                    TrackCode = tracking.Code.ToString(),
                    TrackStatus = tracking.Name,
                    CourierStatus = tracking.Description,
                    Date = date
                });
            }
            else
            {
                return new(false, "Link Mappping is not set in database");
            }
        }

        public async Task<BaseResponse<TrackingMapResponse>> TaroffTrack()
        {
            var trackRequest = new GetTaroffTrackQuery()
            {
                OrderId = Convert.ToInt32(_query.TrackCode)
            };

            var result = await _mediator.Send(trackRequest);
            if (!result.IsSuccess)
            {
                return new(false, result.Message);
            }
            var status = result.Data.StateId;
            var date = "";

            var tracking = await GetPostexStatus(SharedKernel.Common.Enums.CourierCode.Taroff, status.ToString());
            if (tracking != null)
            {
                return new(true, "success", new TrackingMapResponse()
                {
                    CourierStatusMappingId = tracking.Id,
                    TrackCode = tracking.Code.ToString(),
                    TrackStatus = tracking.Name,
                    CourierStatus = tracking.Description,
                    Date = date
                });
            }
            else
            {
                return new(false, "Tarrof Mappping is not set in database");
            }
        }

        public async Task<BaseResponse<TrackingMapResponse>> PishroPostTrack()
        {
            var trackRequest = new GetPishroPostTrackQuery()
            {
                Order = new()
                {
                    Reference = _query.TrackCode,
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

            var tracking = await GetPostexStatus(SharedKernel.Common.Enums.CourierCode.PishroPost, finalStatus);
            if (tracking == null)
            {
                return new(false, "Pishro Post Mappping is not set in database");
            }
            return new(true, "success", new TrackingMapResponse()
            {
                CourierStatusMappingId = tracking.Id,
                TrackCode = tracking.Code.ToString(),
                TrackStatus = tracking.Name,
                CourierStatus = tracking.Description,
                Date = date
            });
        }

        public async Task<BaseResponse<TrackingMapResponse>> SpeedTrack()
        {
            var trackRequest = new GetSpeedTrackQuery()
            {
                Barcode = Convert.ToInt64(_query.TrackCode)
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

            var tracking = await GetPostexStatus(SharedKernel.Common.Enums.CourierCode.Speed, status);
            if (tracking == null)
            {
                return new(false, "Speed Mappping is not set in database");
            }
            return new(true, "success", new TrackingMapResponse()
            {
                CourierStatusMappingId = tracking.Id,
                TrackCode = tracking.Code.ToString(),
                TrackStatus = tracking.Name,
                CourierStatus = tracking.Description,
                Date = date
            });
        }

        public async Task<BaseResponse<TrackingMapResponse>> EcoPeykTrack()
        {
            var trackRequest = new GetEcoPeykStatusQuery()
            {
                Code = _query.TrackCode
            };

            var result = await _mediator.Send(trackRequest);
            if (!result.IsSuccess)
            {
                return new(false, result.Message);
            }
            var status = result.Data.StatusCode;
            var date = "";

            var tracking = await GetPostexStatus(SharedKernel.Common.Enums.CourierCode.EcoPeyk, status.ToString());
            if (tracking != null)
            {
                return new(true, "success", new TrackingMapResponse()
                {
                    CourierStatusMappingId = tracking.Id,
                    TrackCode = tracking.Code.ToString(),
                    TrackStatus = tracking.Name,
                    CourierStatus = tracking.Description,
                    Date = date
                });
            }
            else
            {
                return new(false, "EcoPeyk Mappping is not set in database");
            }
        }
    }
}
