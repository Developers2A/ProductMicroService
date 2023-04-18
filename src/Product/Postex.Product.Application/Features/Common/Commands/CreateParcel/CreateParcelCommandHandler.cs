using MediatR;
using Postex.Product.Application.Dtos.Commons.CreateParcel.Response;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Dtos.ServiceProviders.Chapar.Common;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Dtos.ServiceProviders.Mahex.Common;
using Postex.Product.Application.Features.CityZipCodes.Queries;
using Postex.Product.Application.Features.Common.Commands.CreatePeykOrder;
using Postex.Product.Application.Features.Common.Queries.GetValueAddedPrices;
using Postex.Product.Application.Features.CourierCityMappings.Queries;
using Postex.Product.Application.Features.CourierServices.Queries;
using Postex.Product.Application.Features.ServiceProviders.Chapar.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Kbk.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Mahex.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Mahex.Queries.GetPrice;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetPrice;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Exceptions;

namespace Postex.Product.Application.Features.Common.Commands.CreateParcel
{
    public class CreateParcelCommandHandler : IRequestHandler<CreateParcelCommand, BaseResponse<ParcelResponseDto>>
    {
        private readonly IMediator _mediator;
        private CreateParcelCommand _command;
        private List<CourierCityMappingDto> _courierCityMappings;
        private CourierServiceCommonDto _courierInfo;
        private string _generatedPostCode;

        public CreateParcelCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<ParcelResponseDto>> Handle(CreateParcelCommand command, CancellationToken cancellationToken)
        {
            _command = command;
            await SetCourierInfo();
            BaseResponse<ParcelResponseDto> result = new();

            if (_command.Courier.ServiceType == (int)CourierServiceCode.PostSefareshi || _command.Courier.ServiceType == (int)CourierServiceCode.PostVizhe || _command.Courier.ServiceType == (int)CourierServiceCode.PostPishtaz)
            {
                _courierCityMappings = await GetCourierCityMapping(SharedKernel.Common.Enums.CourierCode.Post);
                result = await CreatePostOrder();
            }
            else if (_command.Courier.ServiceType == (int)CourierServiceCode.Mahex)
            {
                _courierCityMappings = await GetCourierCityMapping(SharedKernel.Common.Enums.CourierCode.Mahex);
                result = await CreateMahexOrder();
            }
            else if (_command.Courier.ServiceType == (int)CourierServiceCode.Chapar || _command.Courier.ServiceType == (int)CourierServiceCode.ChaparExpress)
            {
                _courierCityMappings = await GetCourierCityMapping(SharedKernel.Common.Enums.CourierCode.Chapar);
                result = await CreateChaparOrder();
            }
            else if (_command.Courier.ServiceType == (int)CourierServiceCode.Kalaresan)
            {
                _courierCityMappings = await GetCourierCityMapping(SharedKernel.Common.Enums.CourierCode.Kalaresan);
                result = await CreateKbkOrder();
            }
            else
            {
                result = await CreatePeykOrder();
            }

            SetCourierInfoToResult(result);

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

        private void SetCourierInfoToResult(BaseResponse<ParcelResponseDto> result)
        {
            if (result.Data != null)
            {
                var courier = new CourierResponseDto()
                {
                    Courier = _courierInfo.CourierName,
                    Service = _courierInfo.CourierServiceName,
                    TransitTime = _courierInfo.Days,
                    Description = "",
                };
                result.Data.Shipments.ForEach(x => x.Courier = courier);
            }
        }

        private async Task<List<ContractValueAddedPriceDto>> GetValueAddedPrices()
        {
            return await _mediator.Send(new GetValueAddedPricesQuery()
            {
                UserId = _command.UserID,
                CityId = _courierCityMappings.FirstOrDefault()!.CityId,
                ProvinceId = _courierCityMappings.FirstOrDefault()!.ProvinceId,
                ValueAddedIds = _command.ValueAddedTypeIds
            });
        }

        public async Task<List<CourierCityMappingDto>> GetCourierCityMapping(SharedKernel.Common.Enums.CourierCode courierCode)
        {
            return await _mediator.Send(new GetCourierCityMappingsByCourierAndCitiesQuery()
            {
                CourierCode = (int)courierCode,
                CityCodes = new List<int> { _command.From.Location.CityCode, _command.To.Location.CityCode }
            });
        }

        private async Task<BaseResponse<ParcelResponseDto>> CreatePeykOrder()
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

        private async Task SetCourierInfo()
        {
            var couriers = await _mediator.Send(new GetCourierServicesCommonQuery
            {
                CourierServiceCode = _command.Courier.ServiceType
            });

            _courierInfo = couriers.FirstOrDefault()!;
        }

        private async Task<BaseResponse<ParcelResponseDto>> CreatePostOrder()
        {
            var shopId = Convert.ToInt32(_command.PostEcommerceShopId);
            if (shopId == 0)
            {
                throw new AppException($"آی دی فروشگاه الزامی می باشد");
            }

            //دریافت قیمت از پست
            GetPostPriceQuery getPostPriceQuery = CreatePostGetPriceQuery(shopId);
            var getPostPrice = await _mediator.Send(getPostPriceQuery);

            if (!getPostPrice.IsSuccess)
            {
                return new BaseResponse<ParcelResponseDto>()
                {
                    IsSuccess = getPostPrice.IsSuccess,
                    Message = getPostPrice.Message,
                };
            }

            var createPostOrderCommand = CreatePostOrderCommand(getPostPriceQuery);

            // اگر کد پستی گیرنده خالی بود، با توجه به شهر یک کد پستی از جدول CityZipCodes جایگزین می شود
            if (string.IsNullOrEmpty(_command.To.Location.PostCode) || _command.To.Location.PostCode.Trim().Length != 10)
            {
                await GenerateValidPostCode();
                if (!string.IsNullOrEmpty(_generatedPostCode))
                {
                    createPostOrderCommand.CustomerPostalCode = _generatedPostCode;
                }
            }
            var result = await _mediator.Send(createPostOrderCommand);

            //اگر ای پی آی پست خطای کد پستی برگرداند، کد پستی گیرنده جایگزین می شود و درخواست دوباره ارسال می گردد
            if (!result.IsSuccess && result.Message.ToLower().Contains("postalcode"))
            {
                await GenerateValidPostCode();
                if (!string.IsNullOrEmpty(_generatedPostCode))
                {
                    createPostOrderCommand.CustomerPostalCode = _generatedPostCode;
                    result = await _mediator.Send(createPostOrderCommand);
                }
            }
            if (result.IsSuccess && result.Data != null)
            {
                return new BaseResponse<ParcelResponseDto>()
                {
                    IsSuccess = result.IsSuccess,
                    Message = result.Message,
                    Data = new ParcelResponseDto()
                    {
                        AdditionalData = new AdditionalDataResponseDto()
                        {
                            GeneratedPostCode = _generatedPostCode
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
                                    BuyPrice = result.Data.Price.TotalPrice,//PostFare,
                                    SalePrice = result.Data.Price.PostPrice,//TotalPrice,
                                    Vat = Convert.ToInt32(result.Data.Price.PostPrice * 0.09), //result.Data.Price.Tax,
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
            return new BaseResponse<ParcelResponseDto>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
            };
        }

        // به دست آوردن کد پستی معتبر از جدول CityZipCodes
        private async Task GenerateValidPostCode()
        {
            var cityZipCodes = await _mediator.Send(new GetCityZipCodesQuery()
            {
                CityCode = _command.To.Location.CityCode
            });
            if (cityZipCodes == null || !cityZipCodes.Any())
            {
                _generatedPostCode = "";
                return;
            }
            _generatedPostCode = cityZipCodes!.FirstOrDefault()!.ZipCode;
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

        // استخراج کد نگاشت شده شهر با توجه به کوریر 
        private string GetCityMappedCode(SharedKernel.Common.Enums.CourierCode courierCode, int cityId)
        {
            var city = _courierCityMappings.FirstOrDefault(x => x.Courier.Code == courierCode && x.Code == Convert.ToInt32(cityId));
            if (city == null)
            {
                throw new AppException("نگاشت شهر به کوریر درخواستی یافت نشد");
            }
            return city.MappedCode;
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
                ToCityID = Convert.ToInt32(GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Post, _command.To.Location.CityCode)),
                Weight = _command.Parcel.TotalWeight,
                SMSService = false,
                ShopID = shopId,
                ServiceTypeID = GetPostServiceId(),
                PayTypeID = GetPayTypeId()
            };
        }

        private async Task<BaseResponse<ParcelResponseDto>> CreateMahexOrder()
        {
            //دریافت قیمت از ماهکس
            GetMahexPriceQuery getMahexPriceQuery = CreateMahexGetPriceQuery();
            var getMahexPrice = await _mediator.Send(getMahexPriceQuery);

            if (!getMahexPrice.IsSuccess || getMahexPrice.Data.Data == null)
            {
                return new BaseResponse<ParcelResponseDto>()
                {
                    IsSuccess = getMahexPrice.IsSuccess,
                    Message = getMahexPrice.Message,
                };
            }

            var result = await _mediator.Send(CreateMahexCommand());

            if (result.IsSuccess && result.Data != null)
            {
                return new BaseResponse<ParcelResponseDto>()
                {
                    IsSuccess = result.IsSuccess,
                    Message = result.Message,
                    Data = new ParcelResponseDto()
                    {
                        AdditionalData = new AdditionalDataResponseDto()
                        {
                            GeneratedPostCode = _generatedPostCode
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
                                    Barcode = result.Data.Data != null ? result.Data.Data.ShipmentUuid :"",
                                    TrackingNumber = result.Data.Data != null ? result.Data.Data.ShipmentUuid :"",
                                },
                                ShippingRate = new ShippingRateResponseDto()
                                {
                                    PostPrice = new PostPriceResponseDto()
                                    {
                                        PostFare =  0,
                                        TotalPrice = Convert.ToInt32(getMahexPrice.Data.Data.Rate.Amount),
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
                        ServiceCategory = getMahexPrice.Data.Data.DeliveryWindow,
                        ValueAddedService = new List<ValueAddedServiceResponseDto>()
                    }
                };
            }
            return new BaseResponse<ParcelResponseDto>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
            };
        }

        private GetMahexPriceQuery CreateMahexGetPriceQuery()
        {
            return new GetMahexPriceQuery()
            {
                ToAddress = new MahexAddress()
                {
                    Street = _command.To.Location.Address,
                    PostalCode = _command.To.Location.PostCode,
                    CityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Mahex, _command.To.Location.CityCode)
                },
                FromAddress = new MahexAddress()
                {
                    Street = _command.From.Location.Address,
                    PostalCode = _command.From.Location.PostCode,
                    CityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Mahex, _command.From.Location.CityCode)
                },
                Parcels = new List<MahexGetPriceParcel>()
                {
                    new MahexGetPriceParcel()
                    {
                        Id = "1", // یک عدد ثابت به عنوان سناسه بسته
                        Weight = (decimal)_command.Parcel.TotalWeight / 1000,
                        Content = _command.Parcel.ItemName,
                        DeclaredValue = _command.Parcel.TotalValue,
                        Height = _command.Parcel.Height,
                        Length = _command.Parcel.Length,
                        Width = _command.Parcel.Width,
                        PackageType = "",
                    }
                },
                DeclaredValue = _command.Parcel.TotalValue.ToString()
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
                    Type = "LEGAL", //این مقدار همیشه ثابت می باشد
                    Phone = _command.To.Contact.Phone,
                    CityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Mahex, _command.To.Location.CityCode)
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
                    CityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Mahex, _command.From.Location.CityCode)
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

        private async Task<BaseResponse<ParcelResponseDto>> CreateChaparOrder()
        {
            var result = await _mediator.Send(CreateChaparCommand());
            return new BaseResponse<ParcelResponseDto>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Data = new ParcelResponseDto()
                {
                    AdditionalData = new AdditionalDataResponseDto()
                    {
                        GeneratedPostCode = _generatedPostCode
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
                            city_no = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Chapar, _command.From.Location.CityCode),
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
                            city_no =  GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Chapar, _command.To.Location.CityCode),
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

        private async Task<BaseResponse<ParcelResponseDto>> CreateKbkOrder()
        {
            var result = await _mediator.Send(CreateKbkCommand());
            return new BaseResponse<ParcelResponseDto>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Data = new ParcelResponseDto()
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
                OriginCity = Convert.ToInt32(GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Kalaresan, _command.From.Location.CityCode)),
                DestinationCity = Convert.ToInt32(GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Kalaresan, _command.To.Location.CityCode)),
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
