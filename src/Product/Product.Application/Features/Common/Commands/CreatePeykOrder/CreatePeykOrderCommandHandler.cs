using MediatR;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Utilities;
using Product.Application.Dtos.Couriers;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Features.CourierCityMappings.Queries;
using Product.Application.Features.ServiceProviders.EcoPeyk.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Link.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.PishroPost.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Speed.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Taroff.Commands.CreateOrder;
using System.Globalization;

namespace Product.Application.Features.Common.Commands.CreatePeykOrder
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
                        Address = _command.ReceiverAddress,
                        CellPhone = _command.ReceiverMobile,
                        FullName = _command.ReceiverFristName + " " + _command.ReceiverLastName,
                        Latitude  = Convert.ToDecimal(_command.ReceiverLat),
                        Longitude = Convert.ToDecimal(_command.ReceiverLon),
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
                            address = _command.SenderAddress,
                            mobile = _command.SenderMobile,
                            person = _command.SenderFristName + " " + _command.SenderLastName,
                            telephone = _command.SenderMobile,
                            city_no = GetCityMappedCode(CourierCode.PishroPost, _command.SenderCityCode),
                            company = _command.SenderCompany,
                            email = _command.SenderEmail,
                        },
                        receiver = new PishroPostSenderReceiver()
                        {
                            address = _command.ReceiverAddress,
                            mobile = _command.ReceiverMobile,
                            person = _command.ReceiverFristName + " " + _command.ReceiverLastName,
                            telephone = _command.ReceiverMobile,
                            city_no = GetCityMappedCode(CourierCode.PishroPost, _command.ReceiverCityCode),
                            company = _command.ReceiverCompany,
                            email = _command.ReceiverEmail,
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
            var cityCode = GetCityMappedCode(CourierCode.Taroff, _command.ReceiverCityCode);
            return new CreateTaroffOrderCommand()
            {
                FirstName = _command.ReceiverFristName,
                LastName = _command.ReceiverLastName,
                Address = _command.ReceiverAddress,
                Mobile = _command.ReceiverMobile,
                PostCode = _command.ReceiverPostCode,
                ProductTitles = _command.Content,
                TotalWeight = _command.Weight,
                TotalPrice = _command.ApproximateValue,
                Note = _command.Content,
                DeliverTime = _command.DeliveryDate.ToString("HH:mm"),
                Email = _command.ReceiverEmail,
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
                Name = _command.ReceiverFristName,
                LastName = _command.ReceiverLastName,
                Address = _command.ReceiverAddress,
                CellPhone = _command.ReceiverMobile,
                Phone = _command.ReceiverMobile,
                City = "تهران",
                SenderCity = "تهران",
                SenderCellPhone = _command.SenderMobile,
                SenderPhone = _command.SenderMobile,
                SenderName = _command.SenderFristName,
                SenderLastName = _command.SenderLastName,
                SenderLocation = _command.ReceiverLat + " , " + _command.ReceiverLon,
                Weight = _command.Weight,
                SenderAddress = _command.SenderAddress,
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
                       SenderTitle = _command.SenderFristName + " " + _command.SenderLastName,
                       SenderAddress = _command.SenderAddress,
                       SenderPostalCode = _command.SenderPostCode,
                       SenderPhone = _command.SenderMobile,
                       SenderLocation = _command.SenderLon + "," + _command.SenderLat,
                       ReceiverPhone= _command.ReceiverMobile,
                       ReceiverTitle = _command.ReceiverFristName + " " + _command.ReceiverLastName,
                       ReceiverAddress = _command.ReceiverAddress,
                       ReceiverLocation = _command.ReceiverLat + "," + _command.ReceiverLon,
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
                CityCodes = new List<int> { _command.SenderCityCode, _command.ReceiverCityCode }
            });
        }
    }
}
