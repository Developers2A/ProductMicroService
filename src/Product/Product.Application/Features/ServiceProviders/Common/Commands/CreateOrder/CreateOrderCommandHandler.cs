using MediatR;
using Postex.SharedKernel.Common;
using Product.Application.Dtos.CourierServices.Chapar.Common;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Dtos.CourierServices.Mahex.Common;
using Product.Application.Features.ServiceProviders.Chapar.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Kbk.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Mahex.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Post.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Post.Queries.GetPrice;

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
            //if (_command.CourierCode == (int)CourierCode.Post)
            //{
            //    await CreatePostOrder();
            //}
            //if (_command.CourierCode == (int)CourierCode.Mahex)
            //{
            //    await CreateMahexOrder();
            //}

            //if (_command.CourierCode == (int)CourierCode.Chapar)
            //{
            //    await CreateChaparOrder();
            //}

            //if (_command.CourierCode == (int)CourierCode.Kalaresan)
            //{
            //    await CreateChaparOrder();
            //}

            return new BaseResponse<CreateOrderResponse>();
        }

        private async Task CreatePostOrder()
        {
            var createPostOrderCommand = new CreatePostOrderCommand()
            {
                CustomerName = _command.ReceiverFristName,
                CustomerFamily = _command.ReceiverLastName,
                CustomerAddress = _command.ReceiverAddress,
                ParcelContent = _command.Content,
                CustomerMobile = _command.ReceiverMobile,
                CustomerPostalCode = _command.ReceiverPostCode,
                ClientOrderID = _command.ParcelId,
                CustomerEmail = _command.ReceiverEmail,
                CustomerNID = _command.ReceiverNationalCode,
                ParcelCategoryID = 0, //
            };

            var getPostPrice = await _mediator.Send(CreatePostGetPriceQuery());

            if (getPostPrice.IsSuccess)
            {
                createPostOrderCommand.Price = new PostPriceRequest()
                {
                    ParcelValue = _command.ApproximateValue,
                    ToCityID = _command.ReceiverCityId,
                    Weight = _command.Weight,
                    SMSService = _command.NotifBySms,
                    ShopID = 0, //_command.ShopId, //
                    PayTypeID = 0,//
                    CollectNeed = true, //
                    NonStandardPackage = false, //
                    ServiceTypeID = 0 // pishtaz va ...
                };
                await _mediator.Send(createPostOrderCommand);
            }
        }

        private GetPostPriceQuery CreatePostGetPriceQuery()
        {
            return new GetPostPriceQuery()
            {
                ParcelValue = _command.ApproximateValue,
                ToCityID = _command.ReceiverCityId,
                Weight = _command.Weight,
                SMSService = _command.NotifBySms,
                ShopID = 0 // _command.ShopId,
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
                    FirstName = _command.ReceiverFristName,
                    LastName = _command.ReceiverLastName,
                    Mobile = _command.ReceiverMobile,
                    Street = _command.ReceiverAddress,
                    PostalCode = _command.ReceiverPostCode,
                    ClientId = "", //
                    NationalId = _command.ReceiverNationalCode,
                    Organization = _command.ReceiverCompany,
                    Type = "",//
                    Phone = _command.ReceiverPhone,
                },
                FromAddress = new MahexAddressDetails()
                {
                    FirstName = _command.SenderFristName,
                    LastName = _command.SenderLastName,
                    Mobile = _command.SenderMobile,
                    Street = _command.SenderAddress,
                    PostalCode = _command.SenderPostCode,
                    ClientId = "", //
                    NationalId = _command.SenderNationalCode,//
                    Organization = _command.SenderCompany,
                    Type = "",//
                },
                Parcels = new List<MahexGetPriceParcel>()
                {
                    new MahexGetPriceParcel()
                    {
                        Weight = _command.Weight,
                        Content = _command.Content,
                        DeclaredValue = _command.ApproximateValue,
                        Height = _command.Height , // from box type
                        Length = _command.Length,
                        Width = _command.Width,
                        PackageType = ""//
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
                            address = _command.SenderAddress,
                            mobile = _command.SenderMobile,
                            person = _command.SenderFristName + " " + _command.SenderLastName,
                            telephone = _command.SenderMobile,
                            city_no = "",
                            postcode = _command.SenderPostCode
                        },
                        receiver = new ChaparSenderReceiver()
                        {
                            address = _command.ReceiverAddress,
                            mobile = _command.ReceiverMobile,
                            person = _command.ReceiverFristName + " " + _command.ReceiverLastName,
                            telephone = _command.ReceiverMobile,
                            city_no = "",
                            postcode = _command.ReceiverPostCode
                        },
                        cn = new CnBulkImport()
                        {
                            weight = _command.Weight.ToString(),
                            content = _command.Content,
                            value = _command.ApproximateValue.ToString(),
                            assinged_pieces = _command.Content,
                            inv_value = 0 , //
                            payment_term = 0, //
                            payment_terms = 0,//
                            height = Convert.ToInt32(_command.Height), // from boxtype
                            length =  Convert.ToInt32(_command.Length),
                            width = Convert.ToInt32(_command.Width),
                            service = "", //
                            date = ""//
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
                senderName = _command.SenderFristName + " " + _command.SenderLastName,
                senderPhone = _command.SenderMobile,
                senderAddr = _command.SenderAddress,
                receiverName = _command.ReceiverFristName + " " + _command.ReceiverLastName,
                receiverPhone = _command.ReceiverMobile,
                receiverAddr = _command.ReceiverAddress,
                Detail = new List<KbkPriceDetailsResponse>()
                {
                    new KbkPriceDetailsResponse()
                    {
                        count = 1,
                        desc = _command.Content,
                        size = _command.BoxType , // getsize here
                    }
                }
            };
        }
    }
}
