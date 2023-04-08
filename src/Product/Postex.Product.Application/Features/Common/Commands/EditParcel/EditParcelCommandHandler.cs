using MediatR;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.UpdateOrder;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.EditParcel
{
    public class EditParcelCommandHandler : IRequestHandler<EditParcelCommand, BaseResponse<EditParcelResponse>>
    {
        private readonly IMediator _mediator;
        private EditParcelCommand _command;

        public EditParcelCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<EditParcelResponse>> Handle(EditParcelCommand command, CancellationToken cancellationToken)
        {
            _command = command;
            if (_command.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Post)
            {
                return await EditPostOrder();
            }
            return new BaseResponse<EditParcelResponse>()
            {
                IsSuccess = false,
                Message = "این کوریر این امکان را ندارد"
            };
        }

        private async Task<BaseResponse<EditParcelResponse>> EditPostOrder()
        {
            var shopId = Convert.ToInt32(_command.PostEcommerceShopId);

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

            return new BaseResponse<EditParcelResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        //private async Task<int> GetShopIdBySenderMobile()
        //{
        //    var postShops = await _mediator.Send(new GetPostShopsQuery()
        //    {
        //        Mobile = _command.SenderMobile
        //    });
        //    if (postShops.Any())
        //    {
        //        return postShops.FirstOrDefault()!.ShopId;
        //    }
        //    return 0;
        //}
    }
}
