using MediatR;
using Postex.SharedKernel.Common;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Features.ServiceProviders.Kbk.Commands.CancelOrder;
using Product.Application.Features.ServiceProviders.Post.Commands.SuspendOrder;
using Product.Application.Features.ServiceProviders.Speed.Commands.CancelOrder;
using Product.Application.Features.ServiceProviders.Taroff.Commands.CancelOrder;
using Product.Domain.Enums;

namespace Product.Application.Features.Common.Commands.CancelOrder
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
                await CancelPostOrder();
            }
            else if (_command.CourierCode == (int)CourierCode.Speed)
            {
                await CancelSpeedOrder();
            }
            else if (_command.CourierCode == (int)CourierCode.Taroff)
            {
                await CancelTaroffOrder();
            }
            else if (_command.CourierCode == (int)CourierCode.Kalaresan)
            {
                await CancelKbkOrder();
            }
            else
            {
                return new BaseResponse<CancelOrderResponse>()
                {
                    IsSuccess = false,
                    Message = "این کوریر امکان کنسل کردن سفارش را ندارد"
                };
            }
            return new BaseResponse<CancelOrderResponse>();
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
                IsSuccess = true,
                Message = "success"
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
    }
}
