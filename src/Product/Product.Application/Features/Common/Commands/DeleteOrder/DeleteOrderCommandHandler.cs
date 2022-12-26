﻿using MediatR;
using Postex.SharedKernel.Common;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Features.ServiceProviders.Post.Commands.DeleteOrder;
using Product.Domain.Enums;

namespace Product.Application.Features.Common.Commands.DeleteOrder
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
                return await CancelPostOrder();
            }

            return new BaseResponse<DeleteOrderResponse>()
            {
                IsSuccess = false,
                Message = "این کوریر امکان حذف کردن سفارش را ندارد"
            };

        }

        private async Task<BaseResponse<DeleteOrderResponse>> CancelPostOrder()
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
    }
}
