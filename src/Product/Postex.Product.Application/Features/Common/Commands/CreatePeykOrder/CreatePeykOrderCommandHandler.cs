using MediatR;
using Postex.Product.Application.Dtos.Commons.CreateOrder.Response;
using Postex.Product.Application.Dtos.Couriers;
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
    public class CreatePeykOrderCommandHandler : IRequestHandler<CreatePeykOrderCommand, BaseResponse<CreateParcelResponseDto>>
    {
        private readonly IMediator _mediator;
        private CreatePeykOrderCommand _command;
        private List<CourierCityMappingDto> _courierCityMappings;

        public CreatePeykOrderCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<CreateParcelResponseDto>> Handle(CreatePeykOrderCommand command, CancellationToken cancellationToken)
        {
            _command = command;

            if (_command.Courier.ServiceType == (int)CourierServiceCode.Link)
            {
                return await CreateLinkOrder();
            }

            if (_command.Courier.ServiceType == (int)CourierServiceCode.Speed)
            {
                return await CreateSpeedOrder();
            }

            if (_command.Courier.ServiceType == (int)CourierServiceCode.Taroff)
            {
                _courierCityMappings = await GetCourierCityMapping(SharedKernel.Common.Enums.CourierCode.Taroff);
                return await CreateTaroffOrder();
            }

            if (_command.Courier.ServiceType == (int)CourierServiceCode.PishroPost)
            {
                _courierCityMappings = await GetCourierCityMapping(SharedKernel.Common.Enums.CourierCode.PishroPost);
                return await CreatePishroPostOrder();
            }

            if (_command.Courier.ServiceType == (int)CourierServiceCode.EcoPeyk)
            {
                return await CreateEcoPeykOrder();
            }

            return new BaseResponse<CreateParcelResponseDto>()
            {
                IsSuccess = false,
                Message = "برای این کوریر ثبت سفارش پیاده سازی نشده است"
            };
        }

        private async Task<BaseResponse<CreateParcelResponseDto>> CreateLinkOrder()
        {
            var result = await _mediator.Send(CreateLinkOrderCommand());
            return new BaseResponse<CreateParcelResponseDto>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Data = new CreateParcelResponseDto()
                {
                    //ParcelCode = result.Data.TrackingCode
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
                        Address = _command.To.Location.Address,
                        CellPhone = _command.To.Contact.Mobile,
                        FullName = _command.To.Contact.FirstName + " " + _command.To.Contact.LastName,
                        Latitude  = Convert.ToDecimal(_command.To.Location.Lat),
                        Longitude = Convert.ToDecimal(_command.To.Location.Lon),
                        ParcelValue = _command.Parcel.TotalValue,
                        Weight = _command.Parcel.TotalWeight,
                    }
                }
            };
        }

        private async Task<BaseResponse<CreateParcelResponseDto>> CreatePishroPostOrder()
        {
            var result = await _mediator.Send(CreatePishroPostCommand());
            return new BaseResponse<CreateParcelResponseDto>()
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
                            address = _command.From.Location.Address,
                            mobile = _command.From.Contact.Mobile,
                            person = _command.From.Contact.FirstName + " " + _command.From.Contact.LastName,
                            telephone = _command.From.Contact.Mobile,
                            city_no = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.PishroPost, _command.From.Location.CityCode),
                            company = _command.From.Contact.Company,
                            email = _command.From.Contact.Email,
                        },
                        receiver = new PishroPostSenderReceiver()
                        {
                            address = _command.From.Location.Address,
                            mobile = _command.From.Contact.Mobile,
                            person = _command.From.Contact.FirstName + " " + _command.From.Contact.LastName,
                            telephone = _command.From.Contact.Mobile,
                            city_no = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.PishroPost, _command.From.Location.CityCode),
                            company = _command.From.Contact.Company,
                            email = _command.From.Contact.Email,
                        },
                        cn = new PishroPostCn()
                        {
                            weight = _command.Parcel.TotalWeight.ToString(),
                            content = _command.Parcel.ItemName,
                            value = _command.Parcel.TotalValue.ToString()
                        }
                    }
                }
            };
        }

        private async Task<BaseResponse<CreateParcelResponseDto>> CreateTaroffOrder()
        {
            var result = await _mediator.Send(CreateTarrofCommand());
            return new BaseResponse<CreateParcelResponseDto>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

        private CreateTaroffOrderCommand CreateTarrofCommand()
        {
            var cityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Taroff, _command.To.Location.CityCode);
            return new CreateTaroffOrderCommand()
            {
                FirstName = _command.To.Contact.FirstName,
                LastName = _command.To.Contact.LastName,
                Mobile = _command.To.Contact.Mobile,
                Address = _command.To.Location.Address,
                PostCode = _command.To.Location.PostCode,
                ProductTitles = _command.Parcel.ItemName,
                TotalWeight = _command.Parcel.TotalWeight,
                TotalPrice = _command.Parcel.TotalValue,
                Note = _command.Parcel.ItemName,
                DeliverTime = _command.Delivery.Date.ToString("HH:mm"),
                Email = _command.To.Contact.Email,
                PaymentMethodId = _command.Courier.PaymentType == (int)PaymentType.Cod ? 1212 : 1213,
                CarrierId = 153,
                CityId = cityCode != "0" ? Convert.ToInt32(cityCode) : 1,
            };
        }

        private async Task<BaseResponse<CreateParcelResponseDto>> CreateSpeedOrder()
        {
            var result = await _mediator.Send(CreateSpeedCommand());
            return new BaseResponse<CreateParcelResponseDto>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Data = new CreateParcelResponseDto()
                {
                    //ParcelCode = result.Data != null ? result.Data.Barcode.ToString() : ""
                }
            };
        }

        private CreateSpeedOrderCommand CreateSpeedCommand()
        {
            return new CreateSpeedOrderCommand()
            {
                Name = _command.To.Contact.FirstName,
                LastName = _command.To.Contact.LastName,
                Address = _command.To.Location.Address,
                CellPhone = _command.To.Contact.Mobile,
                Phone = _command.To.Contact.Phone,
                City = "تهران",
                SenderCity = "تهران",
                SenderCellPhone = _command.From.Contact.Mobile,
                SenderPhone = _command.From.Contact.Phone,
                SenderName = _command.From.Contact.FirstName,
                SenderLastName = _command.From.Contact.LastName,
                SenderLocation = _command.To.Location.Lat + " , " + _command.To.Location.Lon,
                Weight = _command.Parcel.TotalWeight,
                SenderAddress = _command.From.Location.Address,
                Cod = _command.Courier.PaymentType == (int)PaymentType.Cod ? 1 : 0,
                Content = _command.Parcel.ItemName,
                Price = _command.Parcel.TotalValue,
            };
        }

        private async Task<BaseResponse<CreateParcelResponseDto>> CreateEcoPeykOrder()
        {
            var result = await _mediator.Send(CreateEcoPeykCommand());
            return new BaseResponse<CreateParcelResponseDto>()
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
                       SenderTitle = _command.From.Contact.FirstName + " " + _command.From.Contact.LastName,
                       SenderAddress = _command.From.Location.Address,
                       SenderPostalCode = _command.From.Location.PostCode,
                       SenderPhone = _command.From.Contact.Mobile,
                       SenderLocation = _command.From.Location.Lon + "," + _command.From.Location.Lat,
                       ReceiverPhone= _command.From.Contact.Mobile,
                       ReceiverTitle = _command.To.Contact.FirstName + " " + _command.To.Contact.LastName,
                       ReceiverAddress = _command.From.Location.Address,
                       ReceiverLocation = _command.To.Location.Lat + "," + _command.To.Location.Lon,
                       BoxPriceValue = _command.Parcel.TotalValue,
                       CashOnDelivery = _command.Courier.PaymentType == (int)PaymentType.Cod,
                       BoxSize = 1,
                       DeliveryDate = _command.Delivery.Date.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("fa-Ir")),
                       PickupDate = _command.Pickup.Date.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("fa-Ir")),
                       DeliveryShift = _command.Delivery.Date.ToShift(),
                       PickupShift = _command.Pickup.Date.ToShift(),
                    }
                }
            };
        }

        private string GetCityMappedCode(SharedKernel.Common.Enums.CourierCode courierCode, int cityCode)
        {
            var city = _courierCityMappings.FirstOrDefault(x => x.Courier.Code == courierCode && x.Code == Convert.ToInt32(cityCode));
            if (city == null)
            {
                return "0";
            }
            return city.MappedCode;
        }

        public async Task<List<CourierCityMappingDto>> GetCourierCityMapping(SharedKernel.Common.Enums.CourierCode courierCode)
        {
            return await _mediator.Send(new GetCourierCityMappingsByCourierAndCitiesQuery()
            {
                CourierCode = (int)courierCode,
                CityCodes = new List<int> { _command.From.Location.CityCode, _command.To.Location.CityCode }
            });
        }
    }
}
