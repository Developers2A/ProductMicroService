using MediatR;
using Postex.Product.Application.Dtos.CourierServices.Common;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.ReadyToCollectOrder;
using Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.ReadyOrder;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.Common.Commands.ReadyOrder
{
    public class ReadyOrderCommandHandler : IRequestHandler<ReadyOrderCommand, BaseResponse<ReadyOrderResponse>>
    {
        private readonly IMediator _mediator;
        private ReadyOrderCommand _command;

        public ReadyOrderCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<ReadyOrderResponse>> Handle(ReadyOrderCommand command, CancellationToken cancellationToken)
        {
            _command = command;
            if (_command.CourierCode == (int)CourierCode.Post)
            {
                return await ReadyPostOrder();
            }
            if (_command.CourierCode == (int)CourierCode.Taroff)
            {
                return await ReadyTaroffOrder();
            }
            return new BaseResponse<ReadyOrderResponse>()
            {
                IsSuccess = false,
                Message = "این کوریر این امکان را ندارد"
            };
        }

        private async Task<BaseResponse<ReadyOrderResponse>> ReadyPostOrder()
        {
            var result = await _mediator.Send(new ReadyToCollectOrderCommand()
            {
                ParcelCodes = new List<string>() { _command.TrackCode }
            });
            return new BaseResponse<ReadyOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private async Task<BaseResponse<ReadyOrderResponse>> ReadyTaroffOrder()
        {
            var result = await _mediator.Send(new ReadyTaroffOrderCommand()
            {
                OrderId = Convert.ToInt32(_command.TrackCode)
            });
            return new BaseResponse<ReadyOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }
    }
}
