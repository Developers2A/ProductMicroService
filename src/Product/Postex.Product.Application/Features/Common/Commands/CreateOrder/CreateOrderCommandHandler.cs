using MediatR;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Dtos.CourierServices.Chapar.Common;
using Postex.Product.Application.Dtos.CourierServices.Common;
using Postex.Product.Application.Dtos.CourierServices.Mahex.Common;
using Postex.Product.Application.Features.Cities.Queries;
using Postex.Product.Application.Features.Common.Commands.CreatePeykOrder;
using Postex.Product.Application.Features.CourierCityMappings.Queries;
using Postex.Product.Application.Features.PostShops.Queries;
using Postex.Product.Application.Features.ServiceProviders.Chapar.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Kbk.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Mahex.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetPrice;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Exceptions;

namespace Postex.Product.Application.Features.Common.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, BaseResponse<CreateOrderResponse>>
    {
        private readonly IMediator _mediator;
        private CreateOrderCommand _command;
        private List<CourierCityMappingDto> _courierCityMappings;

        public CreateOrderCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<CreateOrderResponse>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            _command = command;

            if (_command.CourierServiceCode == (int)CourierServiceCode.PostSefareshi || _command.CourierServiceCode == (int)CourierServiceCode.PostVizhe || _command.CourierServiceCode == (int)CourierServiceCode.PostPishtaz)
            {
                _courierCityMappings = await GetCourierCityMapping(CourierCode.Post);
                return await CreatePostOrder();
            }
            if (_command.CourierServiceCode == (int)CourierServiceCode.Mahex)
            {
                _courierCityMappings = await GetCourierCityMapping(CourierCode.Mahex);
                return await CreateMahexOrder();
            }
            if (_command.CourierServiceCode == (int)CourierServiceCode.Chapar || _command.CourierServiceCode == (int)CourierServiceCode.ChaparExpress)
            {
                _courierCityMappings = await GetCourierCityMapping(CourierCode.Chapar);
                return await CreateChaparOrder();
            }
            if (_command.CourierServiceCode == (int)CourierServiceCode.Kalaresan)
            {
                _courierCityMappings = await GetCourierCityMapping(CourierCode.Kalaresan);
                return await CreateKbkOrder();
            }
            return await CreatePeykOrder();
        }

        public async Task<List<CourierCityMappingDto>> GetCourierCityMapping(CourierCode courierCode)
        {
            return await _mediator.Send(new GetCourierCityMappingsByCourierAndCitiesQuery()
            {
                CourierCode = (int)courierCode,
                CityCodes = new List<int> { _command.SenderCityCode, _command.ReceiverCityCode }
            });
        }

        private async Task<BaseResponse<CreateOrderResponse>> CreatePeykOrder()
        {
            return await _mediator.Send(new CreatePeykOrderCommand()
            {
                CourierServiceCode = _command.CourierServiceCode,
                PayType = _command.PayType,
                ParcelId = _command.ParcelId,
                ApproximateValue = _command.ApproximateValue,
                Content = _command.Content,
                ReceiverCityCode = _command.ReceiverCityCode,
                ReceiverLat = _command.ReceiverLat,
                ReceiverCompany = _command.ReceiverCompany,
                ReceiverAddress = _command.ReceiverAddress,
                ReceiverFristName = _command.ReceiverFristName,
                ReceiverLastName = _command.ReceiverLastName,
                ReceiverEmail = _command.ReceiverEmail,
                ReceiverMobile = _command.ReceiverMobile,
                ReceiverLon = _command.ReceiverLon,
                ReceiverNationalCode = _command.ReceiverNationalCode,
                ReceiverPostCode = _command.ReceiverPostCode,
                ReceiverPhone = _command.ReceiverPhone,
                SenderCityCode = _command.SenderCityCode,
                SenderLat = _command.SenderLat,
                SenderLon = _command.SenderLon,
                SenderCompany = _command.SenderCompany,
                SenderAddress = _command.SenderAddress,
                SenderFristName = _command.SenderFristName,
                SenderLastName = _command.SenderLastName,
                SenderPhone = _command.SenderPhone,
                SenderMobile = _command.SenderMobile,
                SenderPostCode = _command.SenderPostCode,
                SenderNationalCode = _command.SenderNationalCode,
                SenderEmail = _command.SenderEmail,
                Length = _command.Length,
                Height = _command.Height,
                Width = _command.Width,
                Weight = _command.Weight,
                BoxSize = _command.BoxSize,
                DeliveryDate = _command.DeliveryDate,
                PickupDate = _command.PickupDate,
            });
        }

        private async Task<BaseResponse<CreateOrderResponse>> CreatePostOrder()
        {
            var shopId = await GetShopIdByUserName();
            if (shopId == 0)
            {
                throw new AppException("برای این فرستنده شاپ یافت نشد");
            }
            GetPostPriceQuery getPostPriceQuery = CreatePostGetPriceQuery(shopId);
            var getPostPrice = await _mediator.Send(getPostPriceQuery);

            if (!getPostPrice.IsSuccess)
            {
                return new BaseResponse<CreateOrderResponse>()
                {
                    IsSuccess = getPostPrice.IsSuccess,
                    Message = getPostPrice.Message,
                };
            }

            CreatePostOrderCommand createPostOrderCommand = CreatePostOrderCommand(getPostPriceQuery);
            var result = await _mediator.Send(createPostOrderCommand);
            return new BaseResponse<CreateOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Data = new CreateOrderResponse()
                {
                    ParcelCode = result.Data != null ? result.Data.ParcelCode : "",
                    Price = result.Data == null ? null : new CreateOrderPriceResponse()
                    {
                        COD = result.Data.Price.COD,
                        DeliveryNotifyPrice = result.Data.Price.DeliveryNotifyPrice,
                        DiscountAmount = result.Data.Price.DiscountAmount,
                        DiscountPercent = result.Data.Price.DiscountPercent,
                        EcommercePrice = result.Data.Price.EcommercePrice,
                        ElectronicIDPrice = result.Data.Price.ElectronicIDPrice,
                        InsurancePrice = result.Data.Price.InsurancePrice,
                        NonStandardPrice = result.Data.Price.NonStandardPrice,
                        PostFare = result.Data.Price.PostFare,
                        PostPayFarePrice = result.Data.Price.PostPayFarePrice,
                        PostPrice = result.Data.Price.PostPrice,
                        SendPlacePrice = result.Data.Price.SendPlacePrice,
                        Tax = result.Data.Price.Tax,
                        TotalPrice = result.Data.Price.TotalPrice,
                        SMSPrice = result.Data.Price.SMSPrice,
                    }
                }
            };
        }

        private CreatePostOrderCommand CreatePostOrderCommand(GetPostPriceQuery priceQuery)
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
                ParcelCategoryID = 0
            };

            createPostOrderCommand.Price = new PostPriceRequest()
            {
                ParcelValue = _command.ApproximateValue,
                ToCityID = priceQuery.ToCityID,
                Weight = _command.Weight,
                SMSService = false,
                ShopID = priceQuery.ShopID,
                PayTypeID = priceQuery.PayTypeID,
                CollectNeed = true,
                NonStandardPackage = _command.IsLiquidOrBroken,
                ServiceTypeID = priceQuery.ServiceTypeID
            };
            return createPostOrderCommand;
        }

        public async Task<List<CityDto>> GetCities()
        {
            return await _mediator.Send(new GetCitiesQuery()
            {
                CityCodes = new List<int> { _command.SenderCityCode, _command.ReceiverCityCode }
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
            if (string.IsNullOrEmpty(_command.UserName))
            {
                throw new AppException("نام کاربری الزامی می باشد");
            }
            return await _mediator.Send(new GetPostShopIdQuery()
            {
                Mobile = _command.UserName,
                CityCode = _command.SenderCityCode,
            });
        }

        private int GetPostServiceId()
        {
            if (_command.CourierServiceCode == (int)CourierServiceCode.PostPishtaz)
            {
                return 1;
            }
            else if (_command.CourierServiceCode == (int)CourierServiceCode.PostSefareshi)
            {
                return 2;
            }
            return 3;
        }

        private int GetPayTypeId()
        {
            if (_command.PayType == (int)PayType.Cod)
            {
                return 0;
            }
            else if (_command.PayType == (int)PayType.FreePost)
            {
                return 88;
            }
            return 1;
        }

        private GetPostPriceQuery CreatePostGetPriceQuery(int shopId)
        {
            return new GetPostPriceQuery()
            {
                ParcelValue = _command.ApproximateValue,
                ToCityID = Convert.ToInt32(GetCityMappedCode(CourierCode.Post, _command.ReceiverCityCode)),
                Weight = _command.Weight,
                SMSService = false,
                ShopID = shopId,
                ServiceTypeID = GetPostServiceId(),
                PayTypeID = GetPayTypeId()
            };
        }

        private async Task<BaseResponse<CreateOrderResponse>> CreateMahexOrder()
        {
            var result = await _mediator.Send(CreateMahexCommand());
            return new BaseResponse<CreateOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Data = new CreateOrderResponse()
                {
                    ParcelCode = result.Data != null ? result.Data.Data.ShipmentUuid : ""
                }
            };
        }

        private CreateMahexOrderCommand CreateMahexCommand()
        {
            Random random = new Random();
            return new CreateMahexOrderCommand()
            {
                Reference = random.Next(100, 9999).ToString(),
                ToAddress = new MahexAddressDetails()
                {
                    FirstName = _command.ReceiverFristName,
                    LastName = _command.ReceiverLastName,
                    Mobile = _command.ReceiverMobile,
                    Street = _command.ReceiverAddress,
                    PostalCode = _command.ReceiverPostCode,
                    ClientId = "",
                    NationalId = _command.ReceiverNationalCode,
                    Organization = _command.ReceiverCompany,
                    Type = "LEGAL",
                    Phone = _command.ReceiverPhone,
                    CityCode = GetCityMappedCode(CourierCode.Mahex, _command.ReceiverCityCode)
                },
                FromAddress = new MahexAddressDetails()
                {
                    FirstName = _command.SenderFristName,
                    LastName = _command.SenderLastName,
                    Mobile = _command.SenderMobile,
                    Street = _command.SenderAddress,
                    PostalCode = _command.SenderPostCode,
                    ClientId = "",
                    NationalId = _command.SenderNationalCode,
                    Organization = _command.SenderCompany,
                    Type = "LEGAL",
                    CityCode = GetCityMappedCode(CourierCode.Mahex, _command.SenderCityCode)
                },
                Parcels = new List<MahexGetPriceParcel>()
                {
                    new MahexGetPriceParcel()
                    {
                        Id = _command.ParcelId,
                        Weight = _command.Weight,
                        Content = _command.Content,
                        DeclaredValue = _command.ApproximateValue,
                        Height = _command.Height ,
                        Length = _command.Length,
                        Width = _command.Width,
                        PackageType = "",
                    }
                },
            };
        }

        private async Task<BaseResponse<CreateOrderResponse>> CreateChaparOrder()
        {
            var result = await _mediator.Send(CreateChaparCommand());
            return new BaseResponse<CreateOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Data = new CreateOrderResponse()
                {
                    ParcelCode = result.Data.Objects != null ? result.Data.Objects.Result!.FirstOrDefault()!.Tracking : ""
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
                            address = _command.SenderAddress,
                            mobile = _command.SenderMobile,
                            person = _command.SenderFristName + " " + _command.SenderLastName,
                            telephone = _command.SenderMobile,
                            city_no = GetCityMappedCode(CourierCode.Chapar, _command.SenderCityCode),
                            postcode = _command.SenderPostCode,
                            company = _command.SenderCompany,
                            email = _command.SenderEmail
                        },
                        receiver = new ChaparSenderReceiver()
                        {
                            address = _command.ReceiverAddress,
                            mobile = _command.ReceiverMobile,
                            person = _command.ReceiverFristName + " " + _command.ReceiverLastName,
                            telephone = _command.ReceiverMobile,
                            city_no =  GetCityMappedCode(CourierCode.Chapar, _command.ReceiverCityCode),
                            postcode = _command.ReceiverPostCode,
                            company = _command.ReceiverCompany,
                            email = _command.ReceiverEmail
                        },
                        cn = new CnBulkImport()
                        {
                            weight = _command.Weight.ToString(),
                            content = _command.Content,
                            value = _command.ApproximateValue.ToString(),
                            assinged_pieces = "1",
                            inv_value = 0 , //
                            payment_term = _command.PayType == (int)PayType.Cod ? 1 : 0 , //
                            payment_terms = 0,//
                            height = Convert.ToInt32(_command.Height),
                            length =  Convert.ToInt32(_command.Length),
                            width = Convert.ToInt32(_command.Width),
                            service = _command.CourierServiceCode == (int)CourierServiceCode.ChaparExpress ? "6" : "11", //
                            date = DateTime.Now.ToString("yyyy-MM-dd")//
                        }
                    }
                }
            };
        }

        private async Task<BaseResponse<CreateOrderResponse>> CreateKbkOrder()
        {
            var result = await _mediator.Send(CreateKbkCommand());
            return new BaseResponse<CreateOrderResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Data = new CreateOrderResponse()
                {
                    ParcelCode = result.Data != null ? result.Data.ShipmentCode : ""
                }
            };
        }

        private CreateKbkOrderCommand CreateKbkCommand()
        {
            return new CreateKbkOrderCommand()
            {
                PostexShipmentCode = _command.ParcelId,
                OriginCity = Convert.ToInt32(GetCityMappedCode(CourierCode.Kalaresan, _command.SenderCityCode)),
                DestinationCity = Convert.ToInt32(GetCityMappedCode(CourierCode.Kalaresan, _command.ReceiverCityCode)),
                SenderName = _command.SenderFristName + " " + _command.SenderLastName,
                SenderPhone = _command.SenderMobile,
                SenderAddr = _command.SenderAddress,
                ReceiverName = _command.ReceiverFristName + " " + _command.ReceiverLastName,
                ReceiverPhone = _command.ReceiverMobile,
                ReceiverAddr = _command.ReceiverAddress,
                Detail = new List<PacketsDetail>()
                {
                    new PacketsDetail()
                    {
                        Count = 1,
                        Size = Convert.ToInt32(_command.Width*_command.Height*_command.Length),
                        Description = _command.Content,
                    }
                }
            };
        }
    }
}
