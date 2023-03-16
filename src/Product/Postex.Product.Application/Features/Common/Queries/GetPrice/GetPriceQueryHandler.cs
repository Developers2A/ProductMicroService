using MediatR;
using Microsoft.AspNetCore.Http;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Dtos.ServiceProviders.Mahex.Common;
using Postex.Product.Application.Features.BoxTypes.Queries;
using Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByCustomerAndBoxType;
using Postex.Product.Application.Features.Contratcs.ContractCods.Queries.GetByCustomerAndValuePrice;
using Postex.Product.Application.Features.Contratcs.ContractInsurances.Queries.GetByCustomerAndValuePrice;
using Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByCustomerAndValueAdded;
using Postex.Product.Application.Features.CourierCityMappings.Queries;
using Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetPeykOfflinePrices;
using Postex.Product.Application.Features.Customers.Queries;
using Postex.Product.Application.Features.PostShops.Queries;
using Postex.Product.Application.Features.ServiceProviders.Chapar.Queries.GetPrice;
using Postex.Product.Application.Features.ServiceProviders.Kbk.Queries.GetPrice;
using Postex.Product.Application.Features.ServiceProviders.Mahex.Queries.GetPrice;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetPrice;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Exceptions;

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
        private int? _customerId;

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
                _customerId = await GetCustomerId();
                if (_customerId == 0)
                {
                    _customerId = null;
                    //mina for test throw new AppException($"شناسه مشتری یافت نشد");
                }
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
                Id = _query.BoxTypeId
            });

            if (boxType != null)
            {
                _query.Width = boxType.Width;
                _query.Height = boxType.Height;
                _query.Length = boxType.Length;
            }
        }

        private async Task SetCourierCityMappings()
        {
            _courierCityMappings = await GetCourierCityMapping(_query.CourierCode, _query.SenderCityCode, _query.ReceiverCityCode);
            if (_courierCityMappings == null || !_courierCityMappings.Any())
            {
                throw new Exception("برای این شهرها نگاشتی یافت نشد");
            }
        }

        private async Task<int> ApplyPayType()
        {
            //هزینه اعلامی به شرکت پستی : هزینه کالا + حق سی او دی پستکس + حق بیمه پستکس
            if (_query.PayType == (int)PaymentType.Cod)
            {
                var codValues = await GetCodValues();
                var insuranceValues = await GetInsuranceValues();
                _query.Value = Convert.ToInt32(_query.Value + _query.Value * codValues.DefaultFixedPercent / 100 + codValues.DefaultFixedValue +
                    _query.Value * insuranceValues.DefaultFixedPercent / 100 + insuranceValues.DefaultFixedValue);

                return _query.Value;
            }
            //در زمان دریافت هزینه از تحویل گیرنده تنها ارزش کالا از گیرنده دریافت میشود
            else if (_query.PayType == (int)PaymentType.FreePost)
            {
                return _query.Value;
            }
            //هزینه پستی + خدمات ارزش افزوده ( پیامک ، پرینت ) محاسبه میشود و به عنوان ارزش کالا به شرکت پستی اعلام میگردد .
            else if (_query.PayType == (int)PaymentType.Online)
            {
                var valueAddedPrices = await GetValueAddedPrices();
                _query.Value = Convert.ToInt32(_query.Value + valueAddedPrices.Sum(x => x.DefaultSalePrice));
                //اگر مبلغ کمتر از پنج هزار تومان بود همان پنج هزار تومان در نظر گرفته می شود
                if (_query.Value <= 5000)
                {
                    _query.Value = 5000;
                }
                return _query.Value;
            }
            return 0;
        }

        private async Task<CodPriceDto> GetCodValues()
        {
            //مقدار پیشرض و مقدار کانترکت برحسب شهر، استان و مشتری
            var boxPrice = await _mediator.Send(new GetByCustomerAndValuePriceContractCodQuery()
            {
                CustomerId = _customerId,
                CityId = _courierCityMappings.FirstOrDefault().CityId,
                ProvinceId = _courierCityMappings.FirstOrDefault().ProvinceId,
                ValuePrice = _query.Value
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
            var insurancePrice = await _mediator.Send(new GetByCustomerAndValuePriceContractInsuranceQuery()
            {
                CustomerId = _customerId,
                CityId = _courierCityMappings.FirstOrDefault().CityId,
                ProvinceId = _courierCityMappings.FirstOrDefault().ProvinceId,
                ValuePrice = _query.Value
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

        private async Task<int> GetCustomerId()
        {
            // دریافت آی دی مشتری با استفاده از یورآی دی موجود در هدر درخواست
            var userId = GetUserId();
            if (userId == null)
            {
                return 0;
            }

            try
            {
                var getCustomerResponse = await _mediator.Send(new GetCustomerByUserIdQuery()
                {
                    UserId = userId!.Value
                });
                if (getCustomerResponse.IsSuccess)
                {
                    return getCustomerResponse.Data.Id;
                }
            }
            catch
            {
            }
            return 0;
        }

        private Guid? GetUserId()
        {
            // دریافت شناسه جی یو آی دی مشتری با هدر درخواست
            try
            {
                return Guid.Parse(_httpContext.Request.Headers["x-userid"]);
            }
            catch
            {
            }
            return null;
        }

        public async Task<BaseResponse<GetPriceResponse>> GetPrice()
        {
            GetPriceResponse priceResponse = new();
            List<ServicePriceDto> prices = new();


            if (_query.CourierCode == (int)CourierCode.Kalaresan || _query.CourierCode == (int)CourierCode.All)
            {
                var kbkResponse = await KbkPrice();
                if (kbkResponse != null)
                {
                    prices.Add(kbkResponse);
                }
            }

            if (_query.CourierCode == (int)CourierCode.Mahex || _query.CourierCode == (int)CourierCode.All)
            {
                var mahexResponse = await MahexPrice();
                if (mahexResponse != null)
                {
                    prices.Add(mahexResponse);
                }
            }

            if (_query.CourierCode == (int)CourierCode.Chapar || _query.CourierCode == (int)CourierCode.All)
            {
                var chaparResponse = await ChaparPrice();
                if (chaparResponse != default)
                {
                    prices.AddRange(chaparResponse);
                }
            }

            if (_query.CourierCode == (int)CourierCode.Post || _query.CourierCode == (int)CourierCode.All)
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
                    CourierCode = _query.CourierCode,
                    SenderCityCode = _query.SenderCityCode,
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
            var boxPrice = await _mediator.Send(new GetByCustomerAndBoxTypeContractBoxPriceQuery()
            {
                CustomerId = _customerId,
                CityId = _courierCityMappings.FirstOrDefault()!.CityId,
                ProvinceId = _courierCityMappings.FirstOrDefault()!.ProvinceId,
                BoxTypeId = _query.BoxTypeId
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
            if (_query.ValueAddedIds != null && _query.ValueAddedIds.Any())
            {
                foreach (var item in _query.ValueAddedIds)
                {
                    var valueAddedPrice = await _mediator.Send(new GetByCustomerAndValueAddedContractValueAddedQuery()
                    {
                        CustomerId = _customerId,
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
            string senderCityCode = GetCityMappedCode(CourierCode.Kalaresan, _query.SenderCityCode);
            string receiverCityCode = GetCityMappedCode(CourierCode.Kalaresan, _query.ReceiverCityCode);

            var priceRequest = new GetKbkPriceQuery()
            {
                DestinationCity = int.Parse(receiverCityCode),
                OriginCity = int.Parse(senderCityCode),
                Detail = new List<KbkPriceDetailsRequest>()
                {
                    new()
                    {
                        Count = 1,
                        Size = _query.Weight
                    }
                }
            };

            var result = await _mediator.Send(priceRequest);
            if (result.IsSuccess)
            {
                return new ServicePriceDto()
                {
                    PostexPrice = ChangePrice(CourierCode.Kalaresan, result.Data.ShipmentCost * 10),
                    CourierName = "کالارسان",
                    CourierCode = (int)CourierCode.Kalaresan
                };
            }
            return null;
        }

        private long ChangePrice(CourierCode courierCode, long price)
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

        private string GetCityMappedCode(CourierCode courierCode, int cityCode)
        {
            var city = _courierCityMappings.FirstOrDefault(x => x.Courier.Code == courierCode && x.Code == cityCode);
            if (city == null)
            {
                return "0";
            }
            return city.MappedCode;
        }

        private async Task<int> GetShopId(int cityCode)
        {
            int shopId = await _mediator.Send(new GetPostShopIdQuery()
            {
                CityCode = cityCode,
            });

            if (shopId == 0)
            {
                throw new AppException("فروشگاهی یافت نشد");
            }
            return shopId;
        }

        public async Task<ServicePriceDto> MahexPrice()
        {
            string senderCityCode = GetCityMappedCode(CourierCode.Mahex, _query.SenderCityCode);
            string receiverCityCode = GetCityMappedCode(CourierCode.Mahex, _query.ReceiverCityCode);

            var priceRequest = new GetMahexPriceQuery()
            {
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
                        Weight = (decimal)_query.Weight / 1000,
                        DeclaredValue = _query.Value
                    }
                }
            };

            var result = await _mediator.Send(priceRequest);
            if (result.IsSuccess)
            {
                return new ServicePriceDto()
                {
                    PostexPrice = ChangePrice(CourierCode.Mahex, Convert.ToInt64(result.Data.Data.Rate.Amount)),
                    CourierName = "ماهکس",
                    CourierCode = (int)CourierCode.Mahex
                };
            }
            return null;
        }

        public async Task<List<ServicePriceDto>> ChaparPrice()
        {
            List<ServicePriceDto> priceResult = new();
            string senderCityCode = GetCityMappedCode(CourierCode.Chapar, _query.SenderCityCode);
            string receiverCityCode = GetCityMappedCode(CourierCode.Chapar, _query.ReceiverCityCode);
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
                        Weight = (decimal)_query.Weight / 1000,
                        Value = _query.Value,
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
                        CourierCode = (int)CourierCode.Chapar
                    });
                }
                method = "6";
            }
            return priceResult;
        }

        public async Task<List<ServicePriceDto>> PostPrice()
        {
            List<ServicePriceDto> priceResult = new();
            string senderCityCode = GetCityMappedCode(CourierCode.Post, _query.SenderCityCode);
            string receiverCityCode = GetCityMappedCode(CourierCode.Post, _query.ReceiverCityCode);
            var shopId = await GetShopId(int.Parse(senderCityCode));
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
                    ShopID = shopId,
                    ToCityID = Convert.ToInt32(receiverCityCode),
                    ServiceTypeID = serviceTypeId,
                    PayTypeID = 0,
                    Weight = _query.Weight,
                    ParcelValue = _query.Value
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
                        CourierCode = (int)CourierCode.Post,
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
