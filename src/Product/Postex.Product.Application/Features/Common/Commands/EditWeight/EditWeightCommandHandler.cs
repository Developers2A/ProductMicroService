using MediatR;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Features.PostShops.Queries;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.UpdateWeight;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.Common.Commands.EditWeight
{
    public class EditWeightCommandHandler : IRequestHandler<EditWeightCommand, BaseResponse<EditOrderResponse>>
    {
        private readonly IMediator _mediator;
        private EditWeightCommand _command;

        public EditWeightCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<EditOrderResponse>> Handle(EditWeightCommand command, CancellationToken cancellationToken)
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
            var createPostOrderCommand = new UpdatePostWeightCommand()
            {
                ParcelCode = _command.ParcelCode,
                Weight = _command.Weight,
                ShopID = shopId,
                ParcelValue = _command.ParcelValue,
                NonStandardPackage = _command.NonStandardPackage
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
