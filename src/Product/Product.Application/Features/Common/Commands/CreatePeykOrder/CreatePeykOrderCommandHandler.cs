using MediatR;
using Postex.SharedKernel.Common;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Features.ServiceProviders.Link.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.PishroPost.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Speed.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Taroff.Commands.CreateOrder;
using Product.Domain.Enums;

namespace Product.Application.Features.Common.Commands.CreatePeykOrder
{
    public class CreatePeykOrderCommandHandler : IRequestHandler<CreatePeykOrderCommand, BaseResponse<CreateOrderResponse>>
    {
        private readonly IMediator _mediator;
        private CreatePeykOrderCommand _command;

        public CreatePeykOrderCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<CreateOrderResponse>> Handle(CreatePeykOrderCommand command, CancellationToken cancellationToken)
        {
            _command = command;
            if (_command.CourierCode == (int)CourierCode.Link)
            {
                await CreateLinkOrder();
            }

            if (_command.CourierCode == (int)CourierCode.Speed)
            {
                await CreateSpeedOrder();
            }

            if (_command.CourierCode == (int)CourierCode.Taroff)
            {
                await CreateTaroffOrder();
            }

            if (_command.CourierCode == (int)CourierCode.PishroPost)
            {
                await CreatePishroPostOrder();
            }

            return new BaseResponse<CreateOrderResponse>();
        }

        private async Task CreateLinkOrder()
        {
            await _mediator.Send(CreateLinkOrderCommand());
        }

        private CreateLinkOrderCommand CreateLinkOrderCommand()
        {
            return new CreateLinkOrderCommand()
            {
                OrderCode = Guid.NewGuid().ToString("N"),
                Orders = new List<LinkOrder>()
                {
                    new LinkOrder()
                    {
                        Address = _command.Reciver_Address,
                        CellPhone = _command.Reciver_Mobile,
                        FullName = _command.Reciver_FristName + " " + _command.Reciver_LastName,
                        Latitude  = Convert.ToDecimal(_command.Reciverlat),
                        Longitude = Convert.ToDecimal(_command.Reciverlon),
                        ParcelValue = _command.ApproximateValue,
                        Weight = _command.Weight,
                    }
                }
            };
        }

        private async Task CreatePishroPostOrder()
        {
            await _mediator.Send(CreatePishroPostCommand());
        }

        private CreatePishroPostOrderCommand CreatePishroPostCommand()
        {
            return new CreatePishroPostOrderCommand()
            {
                Bulk = new List<PishroPostBulk>()
                {
                    new PishroPostBulk()
                    {
                        sender = new PishroPostSenderReceiver()
                        {
                            address = _command.Sender_Address,
                            mobile = _command.Sender_Mobile,
                            person = _command.Sender_FristName + " " + _command.Sender_LastName,
                            telephone = _command.Sender_Mobile,
                            city_no = ""
                        },
                        receiver = new PishroPostSenderReceiver()
                        {
                            address = _command.Reciver_Address,
                            mobile = _command.Reciver_Mobile,
                            person = _command.Reciver_FristName + " " + _command.Reciver_LastName,
                            telephone = _command.Reciver_Mobile,
                            city_no = ""
                        },
                        cn = new PishroPostCn()
                        {
                            weight = _command.Weight.ToString(),
                            content = _command.GoodsType,
                            value = _command.ApproximateValue.ToString()
                        }
                    }
                }
            };
        }

        private async Task CreateTaroffOrder()
        {
            await _mediator.Send(CreateTarrofCommand());
        }

        private CreateTaroffOrderCommand CreateTarrofCommand()
        {
            return new CreateTaroffOrderCommand()
            {
                FirstName = _command.Reciver_FristName,
                LastName = _command.Reciver_LastName,
                Address = _command.Reciver_Address,
                Mobile = _command.Reciver_Mobile,
                PostCode = _command.Reciver_PostCode,
                ProductTitles = _command.GoodsType,
                TotalWeight = _command.Weight,
                TotalPrice = _command.ApproximateValue,
                Note = _command.GoodsType
            };
        }

        private async Task CreateSpeedOrder()
        {
            await _mediator.Send(CreateSpeedCommand());
        }

        private CreateSpeedOrderCommand CreateSpeedCommand()
        {
            return new CreateSpeedOrderCommand()
            {
                Name = _command.Reciver_FristName,
                LastName = _command.Reciver_LastName,
                Address = _command.Reciver_Address,
                CellPhone = _command.Reciver_Mobile,
                Phone = _command.Reciver_Mobile,
                City = "تهران",
                SenderCellPhone = _command.Sender_Mobile,
                SenderPhone = _command.Sender_Mobile,
                SenderLastName = _command.Sender_LastName,
                SenderName = _command.Sender_FristName,
                SenderLocation = _command.Sender_Address,
                Weight = _command.Weight,
                SenderAddress = _command.Sender_Address,
                Cod = _command.IsCOD == true ? 1 : 0,
                Content = _command.GoodsType,
                Price = _command.ApproximateValue,
            };
        }
    }
}
