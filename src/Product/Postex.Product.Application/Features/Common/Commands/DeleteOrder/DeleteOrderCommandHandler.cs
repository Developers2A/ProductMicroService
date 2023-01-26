using MediatR;
using Postex.Product.Application.Dtos.CourierServices.Common;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.DeleteOrder;
using Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.DeleteOrder;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.Common.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, BaseResponse<DeleteOrderResponse>>
    {
        private readonly IMediator _mediator;
        private DeleteOrderCommand _command;

        public DeleteOrderCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<DeleteOrderResponse>> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            _command = command;
            if (_command.CourierCode == (int)CourierCode.Post)
            {
                return await DeletePostOrder();
            }
            if (_command.CourierCode == (int)CourierCode.Taroff)
            {
                return await DeleteTaroffOrder();
            }

            return new BaseResponse<DeleteOrderResponse>()
            {
                IsSuccess = false,
                Message = "این کوریر امکان حذف کردن سفارش را ندارد"
            };

        }

        private async Task<BaseResponse<DeleteOrderResponse>> DeletePostOrder()
        {
            var result = await _mediator.Send(new DeletePostOrderCommand()
            {
                ParcelCodes = new List<string>() { _command.TrackCode }
            });
            return new BaseResponse<DeleteOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private async Task<BaseResponse<DeleteOrderResponse>> DeleteTaroffOrder()
        {
            var result = await _mediator.Send(new DeleteTaroffOrderCommand()
            {
                OrderId = Convert.ToInt32(_command.TrackCode)
            });
            return new BaseResponse<DeleteOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }
    }
}
