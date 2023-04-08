using MediatR;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.DeleteOrder;
using Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.DeleteOrder;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.DeleteParcel
{
    public class DeleteParcelCommandHandler : IRequestHandler<DeleteParcelCommand, BaseResponse<DeleteParcelResponse>>
    {
        private readonly IMediator _mediator;
        private DeleteParcelCommand _command;

        public DeleteParcelCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<DeleteParcelResponse>> Handle(DeleteParcelCommand command, CancellationToken cancellationToken)
        {
            _command = command;
            if (_command.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Post)
            {
                return await DeletePostOrder();
            }
            if (_command.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Taroff)
            {
                return await DeleteTaroffOrder();
            }

            return new BaseResponse<DeleteParcelResponse>()
            {
                IsSuccess = false,
                Message = "این کوریر امکان حذف کردن سفارش را ندارد"
            };

        }

        private async Task<BaseResponse<DeleteParcelResponse>> DeletePostOrder()
        {
            var result = await _mediator.Send(new DeletePostOrderCommand()
            {
                ParcelCodes = new List<string>() { _command.TrackCode }
            });
            return new BaseResponse<DeleteParcelResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private async Task<BaseResponse<DeleteParcelResponse>> DeleteTaroffOrder()
        {
            var result = await _mediator.Send(new DeleteTaroffOrderCommand()
            {
                OrderId = Convert.ToInt32(_command.TrackCode)
            });
            return new BaseResponse<DeleteParcelResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }
    }
}
