using MediatR;
using Microsoft.AspNetCore.Http;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Dtos.Commons.CreateOrder.Response;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Dtos.ServiceProviders.Chapar.Common;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Dtos.ServiceProviders.Mahex.Common;
using Postex.Product.Application.Features.Cities.Queries;
using Postex.Product.Application.Features.Common.Commands.CreatePeykOrder;
using Postex.Product.Application.Features.Common.Queries.GetValueAddedPrices;
using Postex.Product.Application.Features.CourierCityMappings.Queries;
using Postex.Product.Application.Features.CourierServices.Queries;
using Postex.Product.Application.Features.PostShops.Queries;
using Postex.Product.Application.Features.ServiceProviders.Chapar.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Kbk.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Mahex.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetPrice;
using Postex.Product.Application.Features.Users.Queries;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Exceptions;

namespace Postex.Product.Application.Features.Common.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, BaseResponse<CreateOrderResponseDto>>
    {
        private readonly IMediator _mediator;
        private readonly HttpContext _httpContext;
        private CreateOrderCommand _command;
        private List<CourierCityMappingDto> _courierCityMappings;
        private Guid? _userId;
        private CourierServiceCommonDto _courierInfo;

        public CreateOrderCommandHandler(IMediator mediator, IHttpContextAccessor contextAccessor)
        {
            _mediator = mediator;
            _httpContext = contextAccessor.HttpContext;
        }

        public async Task<BaseResponse<CreateOrderResponseDto>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            _command = command;
            await SetCourierInfo();
            BaseResponse<CreateOrderResponseDto> result = new();

            if (_command.Courier.ServiceType == (int)CourierServiceCode.PostSefareshi || _command.Courier.ServiceType == (int)CourierServiceCode.PostVizhe || _command.Courier.ServiceType == (int)CourierServiceCode.PostPishtaz)
            {
                _userId = GetUserId();
                _courierCityMappings = await GetCourierCityMapping(CourierCode.Post);
                result = await CreatePostOrder();
            }
            else if (_command.Courier.ServiceType == (int)CourierServiceCode.Mahex)
            {
                _courierCityMappings = await GetCourierCityMapping(CourierCode.Mahex);
                result = await CreateMahexOrder();
            }
            else if (_command.Courier.ServiceType == (int)CourierServiceCode.Chapar || _command.Courier.ServiceType == (int)CourierServiceCode.ChaparExpress)
            {
                _courierCityMappings = await GetCourierCityMapping(CourierCode.Chapar);
                result = await CreateChaparOrder();
            }
            else if (_command.Courier.ServiceType == (int)CourierServiceCode.Kalaresan)
            {
                _courierCityMappings = await GetCourierCityMapping(CourierCode.Kalaresan);
                result = await CreateKbkOrder();
            }
            else
            {
                result = await CreatePeykOrder();
            }

            if (result.Data != null && _command.ValueAddedTypeIds != null && _command.ValueAddedTypeIds.Any())
            {
                var valueAddedPriceDtos = await GetValueAddedPrices();
                result.Data.ValueAddedService = valueAddedPriceDtos.Select(x => new ValueAddedServiceResponseDto()
                {
                    BuyPrice = Convert.ToInt32(x.ContractBuyPrice),
                    SalePrice = Convert.ToInt32(x.ContractSalePrice),
                    ContractId = x.ContractId,
                    ContractDetailId = x.ContractValueAddedId,
                    ValueTypeId = x.ContractValueAddedId,
                    ValueTypeName = x.ValueTypeName
                }).ToList();
            }
            return result;
        }

        private async Task<List<ContractValueAddedPriceDto>> GetValueAddedPrices()
        {
            return await _mediator.Send(new GetValueAddedPricesQuery()
            {
                UserId = _userId,
                CityId = _courierCityMappings.FirstOrDefault()!.CityId,
                ProvinceId = _courierCityMappings.FirstOrDefault()!.ProvinceId,
                ValueAddedIds = _command.ValueAddedTypeIds
            });
        }

        public async Task<List<CourierCityMappingDto>> GetCourierCityMapping(CourierCode courierCode)
        {
            return await _mediator.Send(new GetCourierCityMappingsByCourierAndCitiesQuery()
            {
                CourierCode = (int)courierCode,
                CityCodes = new List<int> { _command.From.Location.CityCode, _command.To.Location.CityCode }
            });
        }

        private async Task<BaseResponse<CreateOrderResponseDto>> CreatePeykOrder()
        {
            return await _mediator.Send(new CreatePeykOrderCommand()
            {
                Courier = _command.Courier,
                From = _command.From,
                To = _command.To,
                Pickup = _command.Pickup,
                Delivery = _command.Delivery,
                Parcel = _command.Parcel,
            });
        }

        private Guid? GetUserId()
        {
            try
            {
                return Guid.Parse(_httpContext.Request.Headers["x-userid"]);
            }
            catch (Exception ex)
            {
                throw new AppException($"شناسه کاربر الزامی می باشد");
            }
        }

        private async Task SetCourierInfo()
        {
            var couriers = await _mediator.Send(new GetCourierServicesCommonQuery
            {
                CourierServiceCode = _command.Courier.ServiceType
            });

            _courierInfo = couriers.FirstOrDefault()!;
        }

        private async Task<BaseResponse<CreateOrderResponseDto>> CreatePostOrder()
        {
            var shopId = await GetShopIdByUserName();
            if (shopId == 0)
            {
                throw new AppException($"برای این شخص  {_command.From.Contact.Mobile} شاپ یافت نشد");
            }
            GetPostPriceQuery getPostPriceQuery = CreatePostGetPriceQuery(shopId);
            var getPostPrice = await _mediator.Send(getPostPriceQuery);

            if (!getPostPrice.IsSuccess)
            {
                return new BaseResponse<CreateOrderResponseDto>()
                {
                    IsSuccess = getPostPrice.IsSuccess,
                    Message = getPostPrice.Message,
                };
            }

            CreatePostOrderCommand createPostOrderCommand = CreatePostOrderCommand(getPostPriceQuery);
            var result = await _mediator.Send(createPostOrderCommand);
            if (result.IsSuccess && result.Data != null)
            {
                return new BaseResponse<CreateOrderResponseDto>()
                {
                    IsSuccess = result.IsSuccess,
                    Message = result.Message,
                    Data = new CreateOrderResponseDto()
                    {
                        AdditionalData = new AdditionalDataResponseDto()
                        {
                            GeneratedPostCode = result.Data != null ? result.Data.ParcelCode : ""
                        },
                        Shipments = new List<ShipmentResponseDto>()
                        {
                            new ShipmentResponseDto()
                            {
                                Courier = new CourierResponseDto()
                                {
                                    Courier = _courierInfo.CourierName,
                                    Service = _courierInfo.CourierServiceName,
                                    TransitTime = _courierInfo.Days,
                                    Description = "",
                                },
                                Step = 1,
                                Tracking = new TrackingResponseDto()
                                {
                                    Barcode = result.Data != null ? result.Data.ParcelCode : "",
                                    TrackingNumber = result.Data != null ? result.Data.ParcelCode : ""
                                },
                                ShippingRate = new ShippingRateResponseDto()
                                {
                                    BuyPrice = result.Data.Price.PostFare,
                                    SalePrice = result.Data.Price.TotalPrice,
                                    Vat = result.Data.Price.Tax,
                                    PostPrice = new PostPriceResponseDto()
                                    {
                                        PostFare =  result.Data.Price.PostFare,
                                        TotalPrice = result.Data.Price.TotalPrice,
                                        COD = result.Data.Price.COD,
                                        DeliveryNotifyPrice = result.Data.Price.DeliveryNotifyPrice,
                                        DiscountAmount = result.Data.Price.DiscountAmount,
                                        DiscountPercent = result.Data.Price.DiscountPercent,
                                        EcommercePrice = result.Data.Price.EcommercePrice,
                                        ElectronicIDPrice = result.Data.Price.ElectronicIDPrice,
                                        InsurancePrice = result.Data.Price.InsurancePrice,
                                        NonStandardPrice = result.Data.Price.NonStandardPrice,
                                        PostPayFarePrice = result.Data.Price.PostPayFarePrice,
                                        PostPrice = result.Data.Price.PostPrice,
                                        SendPlacePrice = result.Data.Price.SendPlacePrice,
                                        Tax = result.Data.Price.Tax,
                                        SMSPrice = result.Data.Price.SMSPrice
                                    }
                                }
                            }
                        },
                        IsOversized = false,
                        ServiceCategory = "",
                        ValueAddedService = new List<ValueAddedServiceResponseDto>()
                    }
                };
            }
            return new BaseResponse<CreateOrderResponseDto>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
            };
        }

        private CreatePostOrderCommand CreatePostOrderCommand(GetPostPriceQuery priceQuery)
        {
            var createPostOrderCommand = new CreatePostOrderCommand
            {
                CustomerName = _command.To.Contact.FirstName,
                CustomerFamily = _command.To.Contact.LastName,
                CustomerAddress = _command.To.Location.Address,
                ParcelContent = _command.Parcel.ItemName,
                CustomerMobile = _command.To.Contact.Mobile,
                CustomerEmail = _command.To.Contact.Email,
                CustomerNID = _command.To.Contact.NationalCode,
                CustomerPostalCode = _command.To.Location.PostCode,
                ClientOrderID = "1",
                ParcelCategoryID = 0,
                Price = new PostPriceRequest()
                {
                    ParcelValue = _command.Parcel.TotalValue,
                    ToCityID = priceQuery.ToCityID,
                    Weight = _command.Parcel.TotalWeight,
                    SMSService = false,
                    ShopID = priceQuery.ShopID,
                    PayTypeID = priceQuery.PayTypeID,
                    CollectNeed = true,
                    NonStandardPackage = _command.Parcel.IsLiquid || _command.Parcel.IsFragile,
                    ServiceTypeID = priceQuery.ServiceTypeID
                }
            };
            return createPostOrderCommand;
        }

        public async Task<List<CityDto>> GetCities()
        {
            return await _mediator.Send(new GetCitiesQuery()
            {
                CityCodes = new List<int> { _command.From.Location.CityCode, _command.To.Location.CityCode }
            });
        }

        private string GetCityMappedCode(CourierCode courierCode, int cityId)
        {
            var city = _courierCityMappings.FirstOrDefault(x => x.Courier.Code == courierCode && x.Code == Convert.ToInt32(cityId));
            if (city == null)
            {
                throw new AppException("نگاشت شهر به کوریر درخواستی یافت نشد");
            }
            return city.MappedCode;
        }

        private async Task<int> GetShopIdByUserName()
        {
            //if (string.IsNullOrEmpty(_command.Sender.Mobile))
            //{
            //    throw new AppException("نام کاربری الزامی می باشد");
            //}
            var mobile = await GetUserMobile();
            return await _mediator.Send(new GetPostShopIdQuery()
            {
                Mobile = mobile,
                CityCode = _command.From.Location.CityCode,
            });
        }

        private async Task<string> GetUserMobile()
        {
            var user = await _mediator.Send(new GetUserByIdQuery()
            {
                UserId = _userId.Value
            });

            if (!user.IsSuccess || user.Data == null)
            {
                throw new AppException("فروشگاهی برای این کاربر یافت نشد");
            }
            return user.Data.Mobile;
        }

        private int GetPostServiceId()
        {
            if (_command.Courier.ServiceType == (int)CourierServiceCode.PostPishtaz)
            {
                return 1;
            }
            else if (_command.Courier.ServiceType == (int)CourierServiceCode.PostSefareshi)
            {
                return 2;
            }
            return 3;
        }

        private int GetPayTypeId()
        {
            if (_command.Courier.PaymentType == (int)PaymentType.Cod)
            {
                return 0;
            }
            else if (_command.Courier.PaymentType == (int)PaymentType.FreePost)
            {
                return 88;
            }
            return 1;
        }

        private GetPostPriceQuery CreatePostGetPriceQuery(int shopId)
        {
            return new GetPostPriceQuery()
            {
                ParcelValue = _command.Parcel.TotalValue,
                ToCityID = Convert.ToInt32(GetCityMappedCode(CourierCode.Post, _command.To.Location.CityCode)),
                Weight = _command.Parcel.TotalWeight,
                SMSService = false,
                ShopID = shopId,
                ServiceTypeID = GetPostServiceId(),
                PayTypeID = GetPayTypeId()
            };
        }

        private async Task<BaseResponse<CreateOrderResponseDto>> CreateMahexOrder()
        {
            var result = await _mediator.Send(CreateMahexCommand());
            return new BaseResponse<CreateOrderResponseDto>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Data = new CreateOrderResponseDto()
                {
                    //ParcelCode = result.Data != null ? result.Data.Data.ShipmentUuid : ""
                }
            };
        }

        private CreateMahexOrderCommand CreateMahexCommand()
        {
            Random random = new();
            return new CreateMahexOrderCommand()
            {
                Reference = random.Next(100, 9999).ToString(),
                ToAddress = new MahexAddressDetails()
                {
                    FirstName = _command.To.Contact.FirstName,
                    LastName = _command.To.Contact.LastName,
                    Mobile = _command.To.Contact.Mobile,
                    Street = _command.To.Location.Address,
                    PostalCode = _command.To.Location.PostCode,
                    ClientId = "",
                    NationalId = _command.To.Contact.NationalCode,
                    Organization = _command.To.Contact.Company,
                    Type = "LEGAL",
                    Phone = _command.To.Contact.Phone,
                    CityCode = GetCityMappedCode(CourierCode.Mahex, _command.To.Location.CityCode)
                },
                FromAddress = new MahexAddressDetails()
                {
                    FirstName = _command.From.Contact.FirstName,
                    LastName = _command.From.Contact.LastName,
                    Mobile = _command.From.Contact.Mobile,
                    Street = _command.From.Location.Address,
                    PostalCode = _command.From.Location.PostCode,
                    ClientId = "",
                    NationalId = _command.From.Contact.NationalCode,
                    Organization = _command.From.Contact.Company,
                    Type = "LEGAL",
                    CityCode = GetCityMappedCode(CourierCode.Mahex, _command.From.Location.CityCode)
                },
                Parcels = new List<MahexGetPriceParcel>()
                {
                    new MahexGetPriceParcel()
                    {
                        Id = "1",
                        Weight = _command.Parcel.TotalWeight,
                        Content = _command.Parcel.ItemName,
                        DeclaredValue = _command.Parcel.TotalValue,
                        Height = _command.Parcel.Height ,
                        Length = _command.Parcel.Length,
                        Width = _command.Parcel.Width,
                        PackageType = "",
                    }
                },
            };
        }

        private async Task<BaseResponse<CreateOrderResponseDto>> CreateChaparOrder()
        {
            var result = await _mediator.Send(CreateChaparCommand());
            return new BaseResponse<CreateOrderResponseDto>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Data = new CreateOrderResponseDto()
                {
                    AdditionalData = new AdditionalDataResponseDto()
                    {
                        GeneratedPostCode = ""
                    },
                    Shipments = new List<ShipmentResponseDto>()
                    {
                        new ShipmentResponseDto()
                        {
                            Courier = new CourierResponseDto()
                            {
                                Courier = "post",
                                Service = "",
                                TransitTime = "",
                                Description = "",
                            },
                            Step = 1,
                            Tracking = new TrackingResponseDto()
                            {
                                Barcode = result.Data.Objects != null ? result.Data.Objects.Result!.FirstOrDefault()!.Tracking :"",
                                TrackingNumber = result.Data.Objects != null ? result.Data.Objects.Result!.FirstOrDefault()!.Tracking : ""
                            },
                            ShippingRate = new ShippingRateResponseDto()
                            {
                                PostPrice = new PostPriceResponseDto()
                                {
                                    PostFare =  0,
                                    TotalPrice = 0,
                                    COD = 0,
                                    DeliveryNotifyPrice = 0,
                                    DiscountAmount = 0,
                                    DiscountPercent = 0,
                                    EcommercePrice = 0,
                                    ElectronicIDPrice = 0,
                                    InsurancePrice = 0,
                                    NonStandardPrice = 0,
                                    PostPayFarePrice = 0,
                                    PostPrice = 0,
                                    SendPlacePrice = 0,
                                    Tax = 0,
                                    SMSPrice = 0
                                }
                            }
                        }
                    },
                    IsOversized = false,
                    ServiceCategory = "",
                    ValueAddedService = new List<ValueAddedServiceResponseDto>()
                }
            };
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
                            address = _command.From.Location.Address,
                            mobile = _command.From.Contact.Mobile,
                            person = _command.From.Contact.FirstName + " " + _command.From.Contact.LastName,
                            telephone = _command.From.Contact.Mobile,
                            city_no = GetCityMappedCode(CourierCode.Chapar, _command.From.Location.CityCode),
                            postcode = _command.From.Location.PostCode,
                            company = _command.From.Contact.Company,
                            email = _command.From.Contact.Email
                        },
                        receiver = new ChaparSenderReceiver()
                        {
                            address = _command.To.Location.Address,
                            mobile = _command.To.Contact.Mobile,
                            person = _command.To.Contact.FirstName + " " + _command.To.Contact.LastName,
                            telephone = _command.To.Contact.Mobile,
                            city_no =  GetCityMappedCode(CourierCode.Chapar, _command.To.Location.CityCode),
                            postcode = _command.To.Location.PostCode,
                            company = _command.To.Contact.Company,
                            email = _command.To.Contact.Email
                        },
                        cn = new CnBulkImport()
                        {
                            weight = _command.Parcel.TotalWeight.ToString(),
                            content = _command.Parcel.ItemName,
                            value = _command.Parcel.TotalValue.ToString(),
                            assinged_pieces = "1",
                            inv_value = 0 , //
                            payment_term = _command.Courier.PaymentType == (int)PaymentType.Cod ? 1 : 0 , //
                            payment_terms = 0,//
                            height = Convert.ToInt32(_command.Parcel.Height),
                            length =  Convert.ToInt32(_command.Parcel.Length),
                            width = Convert.ToInt32(_command.Parcel.Width),
                            service = _command.Courier.ServiceType == (int)CourierServiceCode.ChaparExpress ? "6" : "11", //
                            date = DateTime.Now.ToString("yyyy-MM-dd")//
                        }
                    }
                }
            };
        }

        private async Task<BaseResponse<CreateOrderResponseDto>> CreateKbkOrder()
        {
            var result = await _mediator.Send(CreateKbkCommand());
            return new BaseResponse<CreateOrderResponseDto>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Data = new CreateOrderResponseDto()
                {
                    //ParcelCode = result.Data != null ? result.Data.ShipmentCode : ""
                }
            };
        }

        private CreateKbkOrderCommand CreateKbkCommand()
        {
            return new CreateKbkOrderCommand()
            {
                PostexShipmentCode = "1",
                OriginCity = Convert.ToInt32(GetCityMappedCode(CourierCode.Kalaresan, _command.From.Location.CityCode)),
                DestinationCity = Convert.ToInt32(GetCityMappedCode(CourierCode.Kalaresan, _command.To.Location.CityCode)),
                SenderName = _command.From.Contact.FirstName + " " + _command.From.Contact.LastName,
                SenderPhone = _command.From.Contact.Mobile,
                SenderAddr = _command.From.Location.Address,
                ReceiverName = _command.To.Contact.FirstName + " " + _command.To.Contact.LastName,
                ReceiverPhone = _command.To.Contact.Mobile,
                ReceiverAddr = _command.To.Location.Address,
                Detail = new List<PacketsDetail>()
                {
                    new PacketsDetail()
                    {
                        Count = 1,
                        Size = _command.Parcel.TotalWeight,
                        Description = _command.Parcel.ItemName,
                    }
                }
            };
        }
    }
}
