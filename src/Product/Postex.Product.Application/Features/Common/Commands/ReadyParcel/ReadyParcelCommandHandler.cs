using MediatR;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.ReadyToCollectOrder;
using Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.ReadyOrder;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.ReadyParcel
{
    public class ReadyParcelCommandHandler : IRequestHandler<ReadyParcelCommand, BaseResponse<ReadyParcelResponse>>
    {
        private readonly IMediator _mediator;
        private ReadyParcelCommand _command;

        public ReadyParcelCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<ReadyParcelResponse>> Handle(ReadyParcelCommand command, CancellationToken cancellationToken)
        {
            _command = command;
            if (_command.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Post)
            {
                return await ReadyPostOrder();
            }
            if (_command.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Taroff)
            {
                return await ReadyTaroffOrder();
            }
            return new BaseResponse<ReadyParcelResponse>()
            {
                IsSuccess = false,
                Message = "این کوریر این امکان را ندارد"
            };
        }

        private async Task<BaseResponse<ReadyParcelResponse>> ReadyPostOrder()
        {
            var result = await _mediator.Send(new ReadyToCollectOrderCommand()
            {
                ParcelCodes = new List<string>() { _command.TrackCode }
            });
            return new BaseResponse<ReadyParcelResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private async Task<BaseResponse<ReadyParcelResponse>> ReadyTaroffOrder()
        {
            var result = await _mediator.Send(new ReadyTaroffOrderCommand()
            {
                OrderId = Convert.ToInt32(_command.TrackCode)
            });
            return new BaseResponse<ReadyParcelResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }
    }
}
