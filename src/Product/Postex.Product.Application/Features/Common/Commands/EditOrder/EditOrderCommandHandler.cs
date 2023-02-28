using MediatR;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Features.PostShops.Queries;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.UpdateOrder;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.Common.Commands.EditOrder
{
    public class EditOrderCommandHandler : IRequestHandler<EditOrderCommand, BaseResponse<EditOrderResponse>>
    {
        private readonly IMediator _mediator;
        private EditOrderCommand _command;

        public EditOrderCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<EditOrderResponse>> Handle(EditOrderCommand command, CancellationToken cancellationToken)
        {
            _command = command;
            if (_command.CourierCode == (int)CourierCode.Post)
            {
                return await EditPostOrder();
            }
            return new BaseResponse<EditOrderResponse>()
            {
                IsSuccess = false,
                Message = "این کوریر این امکان را ندارد"
            };
        }

        private async Task<BaseResponse<EditOrderResponse>> EditPostOrder()
        {
            var shopId = await GetShopIdBySenderMobile();

            var createPostOrderCommand = new UpdatePostOrderCommand()
            {
                CustomerName = _command.Receiver.FristName,
                CustomerFamily = _command.Receiver.LastName,
                CustomerAddress = _command.Receiver.Address,
                ParcelContent = _command.Content,
                CustomerMobile = _command.Receiver.Mobile,
                CustomerPostalCode = _command.Receiver.PostCode,
                CustomerEmail = _command.Receiver.Email,
                CustomerNID = _command.Receiver.NationalCode,
                ParcelCode = _command.ParcelId,
                ShopID = shopId
            };
            var result = await _mediator.Send(createPostOrderCommand);

            return new BaseResponse<EditOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private async Task<int> GetShopIdBySenderMobile()
        {
            var postShops = await _mediator.Send(new GetPostShopsQuery()
            {
                Mobile = _command.SenderMobile
            });
            if (postShops.Any())
            {
                return postShops.FirstOrDefault()!.ShopId;
            }
            return 0;
        }
    }
}
