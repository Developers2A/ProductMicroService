using MediatR;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Features.ServiceProviders.Kbk.Commands.CancelOrder;
using Postex.Product.Application.Features.ServiceProviders.PishroPost.Commands.CancelOrder;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.SuspendOrder;
using Postex.Product.Application.Features.ServiceProviders.Speed.Commands.CancelOrder;
using Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.CancelOrder;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.CancelParcel
{
    public class CancelParcelCommandHandler : IRequestHandler<CancelParcelCommand, BaseResponse<CancelParcelResponse>>
    {
        private readonly IMediator _mediator;
        private CancelParcelCommand _command;

        public CancelParcelCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<CancelParcelResponse>> Handle(CancelParcelCommand command, CancellationToken cancellationToken)
        {
            _command = command;
            if (_command.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Post)
            {
                return await CancelPostOrder();
            }
            if (_command.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Speed)
            {
                return await CancelSpeedOrder();
            }
            if (_command.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Taroff)
            {
                return await CancelTaroffOrder();
            }
            if (_command.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Kalaresan)
            {
                return await CancelKbkOrder();
            }
            if (_command.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.PishroPost)
            {
                return await CancelPishroPostOrder();
            }
            return new BaseResponse<CancelParcelResponse>()
            {
                IsSuccess = false,
                Message = "این کوریر امکان کنسل کردن سفارش را ندارد"
            };
        }

        private async Task<BaseResponse<CancelParcelResponse>> CancelPostOrder()
        {
            var result = await _mediator.Send(new SuspendPostOrderCommand()
            {
                ParcelCodes = new List<string>() { _command.TrackCode }
            });
            return new BaseResponse<CancelParcelResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private async Task<BaseResponse<CancelParcelResponse>> CancelSpeedOrder()
        {
            var result = await _mediator.Send(new CancelSpeedOrderCommand()
            {
                Barcode = Convert.ToInt64(_command.TrackCode)
            });

            return new BaseResponse<CancelParcelResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private async Task<BaseResponse<CancelParcelResponse>> CancelTaroffOrder()
        {
            var result = await _mediator.Send(new CancelTaroffOrderCommand()
            {
                OrderId = Convert.ToInt32(_command.TrackCode)
            });

            return new BaseResponse<CancelParcelResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private async Task<BaseResponse<CancelParcelResponse>> CancelKbkOrder()
        {
            var result = await _mediator.Send(new CancelKbkOrderCommand()
            {
                ShipmentCode = _command.TrackCode
            });

            return new BaseResponse<CancelParcelResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private async Task<BaseResponse<CancelParcelResponse>> CancelPishroPostOrder()
        {
            var result = await _mediator.Send(new CancelPishroPostOrderCommand()
            {
                ConsignmentNo = _command.TrackCode
            });

            return new BaseResponse<CancelParcelResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }
    }
}
