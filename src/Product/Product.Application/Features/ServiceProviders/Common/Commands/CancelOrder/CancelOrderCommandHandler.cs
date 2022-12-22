using MediatR;
using Postex.SharedKernel.Common;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Features.ServiceProviders.Post.Commands.SuspendOrder;
using Product.Application.Features.ServiceProviders.Speed.Commands.CancelOrder;
using Product.Domain.Enums;

namespace Product.Application.Features.ServiceProviders.Common.Commands.CancelOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, BaseResponse<CreateOrderResponse>>
    {
        private readonly IMediator _mediator;
        private CancelOrderCommand _command;

        public CancelOrderCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<CreateOrderResponse>> Handle(CancelOrderCommand command, CancellationToken cancellationToken)
        {
            _command = command;
            if (_command.CourierCode == (int)CourierCode.Post)
            {
                await CancelPostOrder();
            }
            if (_command.CourierCode == (int)CourierCode.Speed)
            {
                await CancelSpeedOrder();
            }

            return new BaseResponse<CreateOrderResponse>();
        }

        private async Task CancelPostOrder()
        {
            var result = await _mediator.Send(new SuspendOrderCommand()
            {
                ParcelCodes = _command.TrackCodes
            });
        }

        private async Task CancelSpeedOrder()
        {
            foreach (var trackCode in _command.TrackCodes)
            {
                var result = await _mediator.Send(new CancelSpeedOrderCommand()
                {
                    Barcode = Convert.ToInt64(trackCode)
                });
            }
        }
    }
}
