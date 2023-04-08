using MediatR;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.UpdateWeight;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.Common.Commands.EditWeight
{
    public class EditWeightCommandHandler : IRequestHandler<EditWeightCommand, BaseResponse<EditParcelResponse>>
    {
        private readonly IMediator _mediator;
        private EditWeightCommand _command;

        public EditWeightCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<EditParcelResponse>> Handle(EditWeightCommand command, CancellationToken cancellationToken)
        {
            _command = command;

            if (_command.CourierCode != (int)SharedKernel.Common.Enums.CourierCode.Post)
            {
                return new BaseResponse<EditParcelResponse>()
                {
                    IsSuccess = false,
                    Message = "این کوریر این امکان را ندارد"
                };
            }

            if (string.IsNullOrWhiteSpace(_command.PostEcommerceUserID))
                return new BaseResponse<EditParcelResponse>()
                {
                    IsSuccess=false,
                    Message="post ecommerce shop id is missing"
                };

            return await EditPostOrder();
        }

        private async Task<BaseResponse<EditParcelResponse>> EditPostOrder()
        {
            var createPostOrderCommand = new UpdatePostWeightCommand()
            {
                ParcelCode = _command.ParcelCode,
                Weight = _command.Weight,
                ShopID = Convert.ToInt32(_command.PostEcommerceUserID),
                ParcelValue = _command.ParcelValue,
                NonStandardPackage = _command.NonStandardPackage
            };
            var result = await _mediator.Send(createPostOrderCommand);

            return new BaseResponse<EditParcelResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }
    }
}
