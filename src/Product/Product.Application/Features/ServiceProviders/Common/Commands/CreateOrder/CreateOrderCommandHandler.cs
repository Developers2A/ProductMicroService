using MediatR;
using Postex.SharedKernel.Common;
using Product.Application.Dtos.CourierServices.Chapar.Common;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Dtos.CourierServices.Mahex.Common;
using Product.Application.Features.CourierServices.Post.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Chapar.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Kbk.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Mahex.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Post.Queries.GetPrice;
using Product.Domain.Enums;

namespace Product.Application.Features.ServiceProviders.Common.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, BaseResponse<CreateOrderResponse>>
    {
        private readonly IMediator _mediator;
        private CreateOrderCommand _command;

        public CreateOrderCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<CreateOrderResponse>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            _command = command;
            if (_command.CourierCode == (int)CourierCode.Post)
            {
                await CreatePostOrder();
            }
            if (_command.CourierCode == (int)CourierCode.Mahex)
            {
                await CreateMahexOrder();
            }

            if (_command.CourierCode == (int)CourierCode.Chapar)
            {
                await CreateChaparOrder();
            }

            if (_command.CourierCode == (int)CourierCode.Kalaresan)
            {
                await CreateChaparOrder();
            }

            return new BaseResponse<CreateOrderResponse>();
        }

        private async Task CreatePostOrder()
        {
            var createPostOrderCommand = new CreatePostOrderCommand()
            {
                CustomerName = _command.Reciver_FristName,
                CustomerFamily = _command.Reciver_LastName,
                CustomerAddress = _command.Reciver_Address,
                ParcelContent = _command.GoodsType,
                CustomerMobile = _command.Reciver_Mobile,
                CustomerPostalCode = _command.Reciver_PostCode,
            };

            var getPostPrice = await _mediator.Send(CreatePostGetPriceQuery());

            if (getPostPrice.IsSuccess)
            {
                createPostOrderCommand.Price = new PostPriceRequest()
                {
                    ParcelValue = _command.ApproximateValue,
                    ToCityID = _command.Reciver_TownId,
                    Weight = _command.Weight,
                    SMSService = _command.NotifBySms,
                    ShopID = _command.ShopId,
                };
                await _mediator.Send(createPostOrderCommand);
            }
        }

        private GetPostPriceQuery CreatePostGetPriceQuery()
        {
            return new GetPostPriceQuery()
            {
                ParcelValue = _command.ApproximateValue,
                ToCityID = _command.Reciver_TownId,
                Weight = _command.Weight,
                SMSService = _command.NotifBySms,
                ShopID = _command.ShopId,
            };
        }

        private async Task CreateMahexOrder()
        {
            await _mediator.Send(CreateMahexCommand());
        }

        private CreateMahexOrderCommand CreateMahexCommand()
        {
            return new CreateMahexOrderCommand()
            {
                ToAddress = new MahexAddressDetails()
                {
                    FirstName = _command.Reciver_FristName,
                    LastName = _command.Reciver_LastName,
                    Mobile = _command.Reciver_Mobile,
                    Street = _command.Reciver_Address,
                    PostalCode = _command.Reciver_PostCode
                },
                FromAddress = new MahexAddressDetails()
                {
                    FirstName = _command.Sender_FristName,
                    LastName = _command.Sender_LastName,
                    Mobile = _command.Sender_Mobile,
                    Street = _command.Sender_Address,
                    PostalCode = _command.Sender_PostCode,
                },
                Parcels = new List<MahexGetPriceParcel>()
                {
                    new MahexGetPriceParcel()
                    {
                        Weight = _command.Weight,
                        Content = _command.GoodsType,
                        DeclaredValue = _command.ApproximateValue,
                    }
                },

            };
        }

        private async Task CreateChaparOrder()
        {
            await _mediator.Send(CreateChaparCommand());
        }

        private CreateChaparOrderCommand CreateChaparCommand()
        {
            return new CreateChaparOrderCommand()
            {
                Bulk = new List<Bulk>()
                {
                    new Bulk()
                    {
                        sender = new ChaparSenderReceiver()
                        {
                            address = _command.Sender_Address,
                            mobile = _command.Sender_Mobile,
                            person = _command.Sender_FristName + " " + _command.Sender_LastName,
                            telephone = _command.Sender_Mobile,
                            city_no = ""
                        },
                        receiver = new ChaparSenderReceiver()
                        {
                            address = _command.Reciver_Address,
                            mobile = _command.Reciver_Mobile,
                            person = _command.Reciver_FristName + " " + _command.Reciver_LastName,
                            telephone = _command.Reciver_Mobile,
                            city_no = ""
                        },
                        cn = new CnBulkImport()
                        {
                            weight = _command.Weight.ToString(),
                            content = _command.GoodsType,
                            value = _command.ApproximateValue.ToString(),
                            assinged_pieces = _command.GoodsType,
                        }
                    }
                }
            };
        }

        private async Task CreateKbkOrder()
        {
            await _mediator.Send(CreateKbkCommand());
        }

        private CreateKbkOrderCommand CreateKbkCommand()
        {
            return new CreateKbkOrderCommand()
            {
                senderName = _command.Sender_FristName + " " + _command.Sender_LastName,
                senderPhone = _command.Sender_Mobile,
                senderAddr = _command.Sender_Address,
                receiverName = _command.Reciver_FristName + " " + _command.Reciver_LastName,
                receiverPhone = _command.Reciver_Mobile,
                receiverAddr = _command.Reciver_Address,
            };
        }
    }
}
