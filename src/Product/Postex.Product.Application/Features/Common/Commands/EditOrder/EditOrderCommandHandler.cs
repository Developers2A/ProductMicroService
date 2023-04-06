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
            if (_command.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Post)
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
                CustomerName = _command.To.Contact.FirstName,
                CustomerFamily = _command.To.Contact.LastName,
                CustomerAddress = _command.To.Location.Address,
                ParcelContent = _command.Parcel.ItemName,
                CustomerMobile = _command.To.Contact.Mobile,
                CustomerPostalCode = _command.To.Location.PostCode,
                CustomerEmail = _command.To.Contact.Email,
                CustomerNID = _command.To.Contact.NationalCode,
                ParcelCode = _command.Parcel.ParcelCode,
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
