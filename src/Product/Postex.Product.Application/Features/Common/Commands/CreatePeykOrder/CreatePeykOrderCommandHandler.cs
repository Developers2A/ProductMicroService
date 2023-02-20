using MediatR;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Dtos.CourierServices.Common;
using Postex.Product.Application.Features.CourierCityMappings.Queries;
using Postex.Product.Application.Features.ServiceProviders.EcoPeyk.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Link.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.PishroPost.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Speed.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.CreateOrder;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Utilities;
using System.Globalization;

namespace Postex.Product.Application.Features.Common.Commands.CreatePeykOrder
{
    public class CreatePeykOrderCommandHandler : IRequestHandler<CreatePeykOrderCommand, BaseResponse<CreateOrderResponse>>
    {
        private readonly IMediator _mediator;
        private CreatePeykOrderCommand _command;
        private List<CourierCityMappingDto> _courierCityMappings;

        public CreatePeykOrderCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<CreateOrderResponse>> Handle(CreatePeykOrderCommand command, CancellationToken cancellationToken)
        {
            _command = command;

            if (_command.CourierServiceCode == (int)CourierServiceCode.Link)
            {
                return await CreateLinkOrder();
            }

            if (_command.CourierServiceCode == (int)CourierServiceCode.Speed)
            {
                return await CreateSpeedOrder();
            }

            if (_command.CourierServiceCode == (int)CourierServiceCode.Taroff)
            {
                _courierCityMappings = await GetCourierCityMapping(CourierCode.Taroff);
                return await CreateTaroffOrder();
            }

            if (_command.CourierServiceCode == (int)CourierServiceCode.PishroPost)
            {
                _courierCityMappings = await GetCourierCityMapping(CourierCode.PishroPost);
                return await CreatePishroPostOrder();
            }

            if (_command.CourierServiceCode == (int)CourierServiceCode.EcoPeyk)
            {
                return await CreateEcoPeykOrder();
            }

            return new BaseResponse<CreateOrderResponse>()
            {
                IsSuccess = false,
                Message = "برای این کوریر ثبت سفارش پیاده سازی نشده است"
            };
        }

        private async Task<BaseResponse<CreateOrderResponse>> CreateLinkOrder()
        {
            var result = await _mediator.Send(CreateLinkOrderCommand());
            return new BaseResponse<CreateOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Data = new CreateOrderResponse()
                {
                    ParcelCode = result.Data.TrackingCode
                }
            };
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
                        Address = _command.Receiver.Address,
                        CellPhone = _command.Receiver.Mobile,
                        FullName = _command.Receiver.FristName + " " + _command.Receiver.LastName,
                        Latitude  = Convert.ToDecimal(_command.Receiver.Lat),
                        Longitude = Convert.ToDecimal(_command.Receiver.Lon),
                        ParcelValue = _command.ApproximateValue,
                        Weight = _command.Weight,
                    }
                }
            };
        }

        private async Task<BaseResponse<CreateOrderResponse>> CreatePishroPostOrder()
        {
            var result = await _mediator.Send(CreatePishroPostCommand());
            return new BaseResponse<CreateOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
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
                            address = _command.Sender.Address,
                            mobile = _command.Sender.Mobile,
                            person = _command.Sender.FristName + " " + _command.Sender.LastName,
                            telephone = _command.Sender.Mobile,
                            city_no = GetCityMappedCode(CourierCode.PishroPost, _command.Sender.CityCode),
                            company = _command.Sender.Company,
                            email = _command.Sender.Email,
                        },
                        receiver = new PishroPostSenderReceiver()
                        {
                            address = _command.Receiver.Address,
                            mobile = _command.Receiver.Mobile,
                            person = _command.Receiver.FristName + " " + _command.Receiver.LastName,
                            telephone = _command.Receiver.Mobile,
                            city_no = GetCityMappedCode(CourierCode.PishroPost, _command.Receiver.CityCode),
                            company = _command.Receiver.Company,
                            email = _command.Receiver.Email,
                        },
                        cn = new PishroPostCn()
                        {
                            weight = _command.Weight.ToString(),
                            content = _command.Content,
                            value = _command.ApproximateValue.ToString()
                        }
                    }
                }
            };
        }

        private async Task<BaseResponse<CreateOrderResponse>> CreateTaroffOrder()
        {
            var result = await _mediator.Send(CreateTarrofCommand());
            return new BaseResponse<CreateOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private CreateTaroffOrderCommand CreateTarrofCommand()
        {
            var cityCode = GetCityMappedCode(CourierCode.Taroff, _command.Receiver.CityCode);
            return new CreateTaroffOrderCommand()
            {
                FirstName = _command.Receiver.FristName,
                LastName = _command.Receiver.LastName,
                Address = _command.Receiver.Address,
                Mobile = _command.Receiver.Mobile,
                PostCode = _command.Receiver.PostCode,
                ProductTitles = _command.Content,
                TotalWeight = _command.Weight,
                TotalPrice = _command.ApproximateValue,
                Note = _command.Content,
                DeliverTime = _command.DeliveryDate.ToString("HH:mm"),
                Email = _command.Receiver.Email,
                PaymentMethodId = _command.PayType == (int)PayType.Cod ? 1212 : 1213,
                CarrierId = 153,
                CityId = cityCode != "0" ? Convert.ToInt32(cityCode) : 1,
            };
        }

        private async Task<BaseResponse<CreateOrderResponse>> CreateSpeedOrder()
        {
            var result = await _mediator.Send(CreateSpeedCommand());
            return new BaseResponse<CreateOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Data = new CreateOrderResponse()
                {
                    ParcelCode = result.Data != null ? result.Data.Barcode.ToString() : ""
                }
            };
        }

        private CreateSpeedOrderCommand CreateSpeedCommand()
        {
            return new CreateSpeedOrderCommand()
            {
                Name = _command.Receiver.FristName,
                LastName = _command.Receiver.LastName,
                Address = _command.Receiver.Address,
                CellPhone = _command.Receiver.Mobile,
                Phone = _command.Receiver.Mobile,
                City = "تهران",
                SenderCity = "تهران",
                SenderCellPhone = _command.Sender.Mobile,
                SenderPhone = _command.Sender.Mobile,
                SenderName = _command.Sender.FristName,
                SenderLastName = _command.Sender.LastName,
                SenderLocation = _command.Receiver.Lat + " , " + _command.Receiver.Lon,
                Weight = _command.Weight,
                SenderAddress = _command.Sender.Address,
                Cod = _command.PayType == (int)PayType.Cod ? 1 : 0,
                Content = _command.Content,
                Price = _command.ApproximateValue,
            };
        }

        private async Task<BaseResponse<CreateOrderResponse>> CreateEcoPeykOrder()
        {
            var result = await _mediator.Send(CreateEcoPeykCommand());
            return new BaseResponse<CreateOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private CreateEcoPeykOrderCommand CreateEcoPeykCommand()
        {
            return new CreateEcoPeykOrderCommand()
            {
                Type = 1,
                Orders = new List<EcoPeykOrder>()
                {
                    new EcoPeykOrder()
                    {
                       SenderTitle = _command.Sender.FristName + " " + _command.Sender.LastName,
                       SenderAddress = _command.Sender.Address,
                       SenderPostalCode = _command.Sender.PostCode,
                       SenderPhone = _command.Sender.Mobile,
                       SenderLocation = _command.Sender.Lon + "," + _command.Sender.Lat,
                       ReceiverPhone= _command.Receiver.Mobile,
                       ReceiverTitle = _command.Receiver.FristName + " " + _command.Receiver.LastName,
                       ReceiverAddress = _command.Receiver.Address,
                       ReceiverLocation = _command.Receiver.Lat + "," + _command.Receiver.Lon,
                       BoxPriceValue = _command.ApproximateValue,
                       CashOnDelivery = _command.PayType == (int)PayType.Cod,
                       BoxSize = _command.BoxSize ?? 1,
                       DeliveryDate = _command.DeliveryDate.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("fa-Ir")),
                       PickupDate = _command.PickupDate.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("fa-Ir")),
                       DeliveryShift = _command.DeliveryDate.ToShift(),
                       PickupShift = _command.PickupDate.ToShift(),
                    }
                }
            };
        }

        private string GetCityMappedCode(CourierCode courierCode, int cityCode)
        {
            var city = _courierCityMappings.FirstOrDefault(x => x.Courier.Code == courierCode && x.Code == Convert.ToInt32(cityCode));
            if (city == null)
            {
                return "0";
            }
            return city.MappedCode;
        }

        public async Task<List<CourierCityMappingDto>> GetCourierCityMapping(CourierCode courierCode)
        {
            return await _mediator.Send(new GetCourierCityMappingsByCourierAndCitiesQuery()
            {
                CourierCode = (int)courierCode,
                CityCodes = new List<int> { _command.Sender.CityCode, _command.Receiver.CityCode }
            });
        }
    }
}
