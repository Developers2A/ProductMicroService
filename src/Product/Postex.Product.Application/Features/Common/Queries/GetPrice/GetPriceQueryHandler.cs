using MediatR;
using Microsoft.AspNetCore.Http;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Dtos.ServiceProviders.Mahex.Common;
using Postex.Product.Application.Features.BoxTypes.Queries;
using Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByUserAndBoxType;
using Postex.Product.Application.Features.Contratcs.ContractCods.Queries.GetByUserAndValuePrice;
using Postex.Product.Application.Features.Contratcs.ContractInsurances.Queries.GetByUserAndValuePrice;
using Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByUserAndValueAdded;
using Postex.Product.Application.Features.CourierCityMappings.Queries;
using Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetPeykOfflinePrices;
using Postex.Product.Application.Features.ServiceProviders.Chapar.Queries.GetPrice;
using Postex.Product.Application.Features.ServiceProviders.Kbk.Queries.GetPrice;
using Postex.Product.Application.Features.ServiceProviders.Mahex.Queries.GetPrice;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetPrice;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.Common.Queries.GetPrice
{
    /// <summary>
    /// بعد از اینکه قیمت از ای پی آی کوریر مربوطه گرفته شد. قیمت های پیشفرض پستکس و قیمت های کانترکن بر روی آن اعمال می شود
    /// </summary>
    public class GetPriceQueryHandler : IRequestHandler<GetPriceQuery, BaseResponse<GetPriceResponse>>
    {
        private readonly IMediator _mediator;
        private readonly HttpContext _httpContext;
        private List<CourierCityMappingDto> _courierCityMappings;
        private GetPriceQuery _query;

        public GetPriceQueryHandler(IMediator mediator, IHttpContextAccessor contextAccessor)
        {
            _mediator = mediator;
            _httpContext = contextAccessor.HttpContext!;
        }

        public async Task<BaseResponse<GetPriceResponse>> Handle(GetPriceQuery query, CancellationToken cancellationToken)
        {
            _query = query;
            try
            {
                await SetBoxDimensionsIfNeeded();
                await SetCourierCityMappings();
                var tasviePrice = await ApplyPayType();

                return await GetPrice();
            }
            catch (Exception ex)
            {
                return new BaseResponse<GetPriceResponse>(false, ex.Message);
            }
        }

        private async Task SetBoxDimensionsIfNeeded()
        {
            var boxType = await _mediator.Send(new GetBoxTypeByIdQuery()
            {
                Id = _query.Parcel.BoxTypeId
            });

            if (boxType != null)
            {
                _query.Parcel.Width = boxType.Width;
                _query.Parcel.Height = boxType.Height;
                _query.Parcel.Length = boxType.Length;
            }
        }

        private async Task SetCourierCityMappings()
        {
            _courierCityMappings = await GetCourierCityMapping(_query.Courier.CourierCode, _query.Sender.CityCode, _query.Receiver.CityCode);
            if (_courierCityMappings == null || !_courierCityMappings.Any())
            {
                throw new Exception("برای این شهرها نگاشتی یافت نشد");
            }
        }

        private async Task<int> ApplyPayType()
        {
            //هزینه اعلامی به شرکت پستی : هزینه کالا + حق سی او دی پستکس + حق بیمه پستکس
            if (_query.Courier.PaymentType == (int)PaymentType.Cod)
            {
                var codValues = await GetCodValues();
                var insuranceValues = await GetInsuranceValues();
                _query.Parcel.TotalValue = Convert.ToInt32(_query.Parcel.TotalValue + _query.Parcel.TotalValue * codValues.DefaultFixedPercent / 100 + codValues.DefaultFixedValue +
                    _query.Parcel.TotalValue * insuranceValues.DefaultFixedPercent / 100 + insuranceValues.DefaultFixedValue);

                return _query.Parcel.TotalValue;
            }
            //در زمان دریافت هزینه از تحویل گیرنده تنها ارزش کالا از گیرنده دریافت میشود
            else if (_query.Courier.PaymentType == (int)PaymentType.FreePost)
            {
                return _query.Parcel.TotalValue;
            }
            //هزینه پستی + خدمات ارزش افزوده ( پیامک ، پرینت ) محاسبه میشود و به عنوان ارزش کالا به شرکت پستی اعلام میگردد .
            else if (_query.Courier.PaymentType == (int)PaymentType.Online)
            {
                var valueAddedPrices = await GetValueAddedPrices();
                _query.Parcel.TotalValue = Convert.ToInt32(_query.Parcel.TotalValue + valueAddedPrices.Sum(x => x.DefaultSalePrice));
                //اگر مبلغ کمتر از پنج هزار تومان بود همان پنج هزار تومان در نظر گرفته می شود
                if (_query.Parcel.TotalValue <= 5000)
                {
                    _query.Parcel.TotalValue = 5000;
                }
                return _query.Parcel.TotalValue;
            }
            return 0;
        }

        private async Task<CodPriceDto> GetCodValues()
        {
            //مقدار پیشرض و مقدار کانترکت برحسب شهر، استان و مشتری
            var boxPrice = await _mediator.Send(new GetByUserAndValuePriceContractCodQuery()
            {
                UserId = _query.UserID,
                CityId = _courierCityMappings.FirstOrDefault().CityId,
                ProvinceId = _courierCityMappings.FirstOrDefault().ProvinceId,
                ValuePrice = _query.Parcel.TotalValue
            });

            return new CodPriceDto()
            {
                ContractId = boxPrice.ContractId,
                ContractCodId = boxPrice.ContractCodId,
                DefaultFixedPercent = boxPrice.DefaultFixedPercent,
                DefaultFixedValue = boxPrice.DefaultFixedValue,
                ContractFixedPercent = boxPrice.ContractFixedPercent,
                ContractFixedValue = boxPrice.ContractFixedValue,
            };
        }

        private async Task<InsurancePriceDto> GetInsuranceValues()
        {
            //مقدار پیشرض و مقدار کانترکت برحسب شهر، استان و مشتری
            var insurancePrice = await _mediator.Send(new GetByUserAndValuePriceContractInsuranceQuery()
            {
                UserId = _query.UserID,
                CityId = _courierCityMappings.FirstOrDefault().CityId,
                ProvinceId = _courierCityMappings.FirstOrDefault().ProvinceId,
                ValuePrice = _query.Parcel.TotalValue
            });

            return new InsurancePriceDto()
            {
                ContractId = insurancePrice.ContractId,
                ContractInsuranceId = insurancePrice.ContractInsuranceId,
                DefaultFixedPercent = insurancePrice.DefaultFixedPercent,
                DefaultFixedValue = insurancePrice.DefaultFixedValue,
                ContractFixedPercent = insurancePrice.ContractFixedPercent,
                ContractFixedValue = insurancePrice.ContractFixedValue,
            };
        }

        public async Task<BaseResponse<GetPriceResponse>> GetPrice()
        {
            GetPriceResponse priceResponse = new();
            List<ServicePriceDto> prices = new();


            if (_query.Courier.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Kalaresan || _query.Courier.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.All)
            {
                var kbkResponse = await KbkPrice();
                if (kbkResponse != null)
                {
                    prices.Add(kbkResponse);
                }
            }

            if (_query.Courier.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Mahex || _query.Courier.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.All)
            {
                var mahexResponse = await MahexPrice();
                if (mahexResponse != null)
                {
                    prices.Add(mahexResponse);
                }
            }

            if (_query.Courier.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Chapar || _query.Courier.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.All)
            {
                var chaparResponse = await ChaparPrice();
                if (chaparResponse != default)
                {
                    prices.AddRange(chaparResponse);
                }
            }

            if (_query.Courier.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Post || _query.Courier.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.All)
            {
                var postResponse = await PostPrice();
                if (postResponse != default)
                {
                    prices.AddRange(postResponse);
                }
            }

            if (_query.HasCollection || _query.HasDistribution)
            {
                var collectionDistributionPrice = await _mediator.Send(new GetPeykOfflinePricesQuery()
                {
                    CourierCode = _query.Courier.CourierCode,
                    SenderCityCode = _query.Sender.CityCode,
                });

                if (_query.HasCollection && collectionDistributionPrice.CollectionPrices != null)
                {
                    priceResponse.CollectionPrices = collectionDistributionPrice.CollectionPrices.Select(x => new Dtos.ServiceProviders.Common.CollectionDistributionPriceDto()
                    {
                        CourierCode = x.CourierCode,
                        CourierName = x.CourierName,
                        Price = x.Price
                    }).ToList();
                }
                if (_query.HasDistribution && collectionDistributionPrice.DistributionPrices != null)
                {
                    priceResponse.CollectionPrices = collectionDistributionPrice.DistributionPrices.Select(x => new Dtos.ServiceProviders.Common.CollectionDistributionPriceDto()
                    {
                        CourierCode = x.CourierCode,
                        CourierName = x.CourierName,
                        Price = x.Price
                    }).ToList();
                }
            }

            priceResponse.ServicePrices = prices;
            foreach (var servicePrice in priceResponse.ServicePrices)
            {
                servicePrice.ContractInsurancePrice = await GetInsurancePrices(servicePrice.InsurancePrice);
            }
            priceResponse.BoxPrice = await GetBoxPrice();
            priceResponse.ValueAddedPrices = await GetValueAddedPrices();
            return new(true, "success", priceResponse); ;
        }

        private async Task<ContractPriceDto> GetBoxPrice()
        {
            //مقدار پیشرض و مقدار کانترکت برحسب شهر، استان و مشتری
            var boxPrice = await _mediator.Send(new GetByUserAndBoxTypeContractBoxPriceQuery()
            {
                UserId = _query.UserID,
                CityId = _courierCityMappings.FirstOrDefault()!.CityId,
                ProvinceId = _courierCityMappings.FirstOrDefault()!.ProvinceId,
                BoxTypeId = _query.Parcel.BoxTypeId
            });

            return new ContractPriceDto()
            {
                ContractId = boxPrice.ContractId,
                ContractItemId = boxPrice.ContractBoxPriceId,
                DefaultSalePrice = boxPrice.DefaultSalePrice,
                DefaultBuyPrice = boxPrice.DefaultBuyPrice,
                ContractSalePrice = boxPrice.ContractSalePrice,
                ContractBuyPrice = boxPrice.ContractBuyPrice,
            };
        }

        private async Task<List<ContractValueAddedPriceDto>> GetValueAddedPrices()
        {
            //دریافت لیست مبالغ پیشفرض و کانترکت ارزش های افزوده درخواستی برحسب شهر، استان و مشتری
            List<ContractValueAddedPriceDto> valueAddedPriceGetDtos = new();
            if (_query.ValueAddedTypeIds != null && _query.ValueAddedTypeIds.Any())
            {
                foreach (var item in _query.ValueAddedTypeIds)
                {
                    var valueAddedPrice = await _mediator.Send(new GetByUserAndValueAddedContractValueAddedQuery()
                    {
                        UserId = _query.UserID,
                        CityId = _courierCityMappings.FirstOrDefault()!.CityId,
                        ProvinceId = _courierCityMappings.FirstOrDefault()!.ProvinceId,
                        ValueAddedId = item
                    });

                    valueAddedPriceGetDtos.Add(new ContractValueAddedPriceDto()
                    {
                        ContractId = valueAddedPrice.ContractId,
                        ContractValueAddedId = valueAddedPrice.ContractValueAddedId,
                        ValueTypeName = valueAddedPrice.ValueAddedTypeName,
                        DefaultBuyPrice = valueAddedPrice.DefaultBuyPrice,
                        DefaultSalePrice = valueAddedPrice.DefaultSalePrice,
                        ContractBuyPrice = valueAddedPrice.ContractBuyPrice,
                        ContractSalePrice = valueAddedPrice.ContractSalePrice,
                    });
                }
            }

            return valueAddedPriceGetDtos;
        }

        private async Task<ContractInsurancePriceDto> GetInsurancePrices(long courierInsurancePrice)
        {
            //اعمال مبالغ پیشفرض و کانترکت بر روی مبلغ بیمه اعلامی کوریر

            var insurancePrice = await GetInsuranceValues();

            var defaultInsurancePrice = courierInsurancePrice + insurancePrice.DefaultFixedValue + courierInsurancePrice * insurancePrice.DefaultFixedPercent;
            var contractInsurancePrice = courierInsurancePrice + insurancePrice.ContractFixedValue + courierInsurancePrice * insurancePrice.ContractFixedPercent;

            return new ContractInsurancePriceDto()
            {
                ContractId = insurancePrice.ContractId,
                ContractInsuranceId = insurancePrice.ContractInsuranceId,
                DefaultPrice = Convert.ToDecimal(defaultInsurancePrice),
                ContractPrice = Convert.ToDecimal(contractInsurancePrice),
            };
        }


        public async Task<List<CourierCityMappingDto>> GetCourierCityMapping(int courierCode, int senderCity, int receiverCity)
        {
            return await _mediator.Send(new GetCourierCityMappingsByCourierAndCitiesQuery()
            {
                CourierCode = courierCode,
                CityCodes = new List<int> { senderCity, receiverCity }
            });
        }

        public async Task<ServicePriceDto> KbkPrice()
        {
            string senderCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Kalaresan, _query.Sender.CityCode);
            string receiverCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Kalaresan, _query.Receiver.CityCode);

            var priceRequest = new GetKbkPriceQuery()
            {
                DestinationCity = int.Parse(receiverCityCode),
                OriginCity = int.Parse(senderCityCode),
                Detail = new List<KbkPriceDetailsRequest>()
                {
                    new()
                    {
                        Count = 1,
                        Size = _query.Parcel.TotalWeight
                    }
                }
            };

            var result = await _mediator.Send(priceRequest);
            if (result.IsSuccess)
            {
                return new ServicePriceDto()
                {
                    PostexPrice = ChangePrice(SharedKernel.Common.Enums.CourierCode.Kalaresan, result.Data.ShipmentCost * 10),
                    CourierName = "کالارسان",
                    CourierCode = (int)SharedKernel.Common.Enums.CourierCode.Kalaresan
                };
            }
            return null;
        }

        private long ChangePrice(SharedKernel.Common.Enums.CourierCode courierCode, long price)
        {
            var courier = _courierCityMappings.FirstOrDefault(x => x.Courier.Code == courierCode).Courier;
            double taxChangePercent = 0;
            if (courier == null)
            {
                return price;
            }
            else
            {
                double changePrice = price;
                changePrice = 0;// price * courier.PostexPercent / 100; // 4800
                taxChangePercent = changePrice * 9 / 100; // 432  
                changePrice = price + changePrice + taxChangePercent;

                return Convert.ToInt64(changePrice);
            }
        }

        private string GetCityMappedCode(SharedKernel.Common.Enums.CourierCode courierCode, int cityCode)
        {
            var city = _courierCityMappings.FirstOrDefault(x => x.Courier.Code == courierCode && x.Code == cityCode);
            if (city == null)
            {
                return "0";
            }
            return city.MappedCode;
        }

        public async Task<ServicePriceDto> MahexPrice()
        {
            string senderCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Mahex, _query.Sender.CityCode);
            string receiverCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Mahex, _query.Receiver.CityCode);

            var priceRequest = new GetMahexPriceQuery()
            {
                DeclaredValue = _query.Parcel.TotalValue.ToString(),
                FromAddress = new MahexAddress()
                {
                    CityCode = senderCityCode
                },
                ToAddress = new MahexAddress()
                {
                    CityCode = receiverCityCode
                },
                Parcels = new List<MahexGetPriceParcel>()
                {
                    new MahexGetPriceParcel()
                    {
                        Weight = (decimal)_query.Parcel.TotalWeight / 1000,
                        DeclaredValue = _query.Parcel.TotalValue
                    }
                }
            };

            var result = await _mediator.Send(priceRequest);
            if (result.IsSuccess)
            {
                return new ServicePriceDto()
                {
                    PostexPrice = ChangePrice(SharedKernel.Common.Enums.CourierCode.Mahex, Convert.ToInt64(result.Data.Data.Rate.Amount)),
                    CourierName = "ماهکس",
                    CourierCode = (int)SharedKernel.Common.Enums.CourierCode.Mahex
                };
            }
            return null;
        }

        public async Task<List<ServicePriceDto>> ChaparPrice()
        {
            List<ServicePriceDto> priceResult = new();
            string senderCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Chapar, _query.Sender.CityCode);
            string receiverCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Chapar, _query.Receiver.CityCode);
            string method = "11";
            string courier = "";

            for (int i = 0; i < 2; i++)
            {
                if (method == "11")
                {
                    courier = "چاپار";
                }
                else if (method == "6")
                {
                    courier = "چاپار اکسپرس";
                }

                var priceRequest = new GetChaparPriceQuery()
                {
                    Order = new ChaparOrder()
                    {
                        Weight = (decimal)_query.Parcel.TotalWeight / 1000,
                        Value = _query.Parcel.TotalValue,
                        Origin = senderCityCode,
                        Destination = receiverCityCode,
                        Method = method
                    }
                };

                var result = await _mediator.Send(priceRequest);
                if (result.IsSuccess)
                {
                    if (result.Data == null) continue;
                    priceResult.Add(new ServicePriceDto()
                    {
                        PostexPrice = Convert.ToInt64(result.Data.Objects.Order.Quote),
                        CourierName = courier,
                        CourierCode = (int)SharedKernel.Common.Enums.CourierCode.Chapar
                    });
                }
                method = "6";
            }
            return priceResult;
        }

        public async Task<List<ServicePriceDto>> PostPrice()
        {
            List<ServicePriceDto> priceResult = new();
            string senderCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Post, _query.Sender.CityCode);
            string receiverCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Post, _query.Receiver.CityCode);
            var shopId = _query.PostEcommerceShopID;
            int serviceTypeId = 0;
            string courier = "";

            for (int i = 1; i < 4; i++)
            {
                serviceTypeId = i;
                if (serviceTypeId == 1)
                {
                    courier = "پست پیشتاز";
                }
                else if (serviceTypeId == 2)
                {
                    courier = "پست سفارشی";
                }
                else
                {
                    courier = "پست ویژه";
                }
                var priceRequest = new GetPostPriceQuery()
                {
                    ShopID = Convert.ToInt32(shopId),
                    ToCityID = Convert.ToInt32(receiverCityCode),
                    ServiceTypeID = serviceTypeId,
                    PayTypeID = 0,
                    Weight = _query.Parcel.TotalWeight,
                    ParcelValue = _query.Parcel.TotalValue
                };

                var result = await _mediator.Send(priceRequest);
                if (result.IsSuccess)
                {
                    if (result.Data == null) continue;
                    var servicePrice = new ServicePriceDto()
                    {
                        PostexPrice = Convert.ToInt64(result.Data.PostPrice),
                        PostexTax = Convert.ToInt64(result.Data.DiscountAmount * 0.09),
                        TotalPrice = Convert.ToInt64(result.Data.PostPrice * 1.09),
                        CourierTax = result.Data.Tax,
                        CourierName = courier,
                        CourierCode = (int)SharedKernel.Common.Enums.CourierCode.Post,
                        DiscountAmount = result.Data.DiscountAmount,
                        InsurancePrice = result.Data.InsurancePrice
                    };
                    priceResult.Add(servicePrice);
                }
            }
            return priceResult;
        }
    }
}
