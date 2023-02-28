using MediatR;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Features.ServiceProviders.Kbk.Commands.CancelOrder;
using Postex.Product.Application.Features.ServiceProviders.PishroPost.Commands.CancelOrder;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.SuspendOrder;
using Postex.Product.Application.Features.ServiceProviders.Speed.Commands.CancelOrder;
using Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.CancelOrder;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.Common.Commands.CancelOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, BaseResponse<CancelOrderResponse>>
    {
        private readonly IMediator _mediator;
        private CancelOrderCommand _command;

        public CancelOrderCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<CancelOrderResponse>> Handle(CancelOrderCommand command, CancellationToken cancellationToken)
        {
            _command = command;
            if (_command.CourierCode == (int)CourierCode.Post)
            {
                return await CancelPostOrder();
            }
            if (_command.CourierCode == (int)CourierCode.Speed)
            {
                return await CancelSpeedOrder();
            }
            if (_command.CourierCode == (int)CourierCode.Taroff)
            {
                return await CancelTaroffOrder();
            }
            if (_command.CourierCode == (int)CourierCode.Kalaresan)
            {
                return await CancelKbkOrder();
            }
            if (_command.CourierCode == (int)CourierCode.PishroPost)
            {
                return await CancelPishroPostOrder();
            }
            return new BaseResponse<CancelOrderResponse>()
            {
                IsSuccess = false,
                Message = "این کوریر امکان کنسل کردن سفارش را ندارد"
            };
        }

        private async Task<BaseResponse<CancelOrderResponse>> CancelPostOrder()
        {
            var result = await _mediator.Send(new SuspendPostOrderCommand()
            {
                ParcelCodes = new List<string>() { _command.TrackCode }
            });
            return new BaseResponse<CancelOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private async Task<BaseResponse<CancelOrderResponse>> CancelSpeedOrder()
        {
            var result = await _mediator.Send(new CancelSpeedOrderCommand()
            {
                Barcode = Convert.ToInt64(_command.TrackCode)
            });

            return new BaseResponse<CancelOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private async Task<BaseResponse<CancelOrderResponse>> CancelTaroffOrder()
        {
            var result = await _mediator.Send(new CancelTaroffOrderCommand()
            {
                OrderId = Convert.ToInt32(_command.TrackCode)
            });

            return new BaseResponse<CancelOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private async Task<BaseResponse<CancelOrderResponse>> CancelKbkOrder()
        {
            var result = await _mediator.Send(new CancelKbkOrderCommand()
            {
                ShipmentCode = _command.TrackCode
            });

            return new BaseResponse<CancelOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private async Task<BaseResponse<CancelOrderResponse>> CancelPishroPostOrder()
        {
            var result = await _mediator.Send(new CancelPishroPostOrderCommand()
            {
                ConsignmentNo = _command.TrackCode
            });

            return new BaseResponse<CancelOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }
    }
}
