using MediatR;
using Microsoft.AspNetCore.Http;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Dtos.ServiceProviders.Mahex.Common;
using Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByCustomerAndBoxType;
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
            _customerId = await GetCustomerId();
            if (_customerId == 0)
            {
                _customerId = null;
                //mina for test throw new AppException($"شناسه مشتری یافت نشد");
            }
            return await GetPrice();
        }

        private async Task<int> GetCustomerId()
        {
            var userId = GetUserId();
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
                throw new AppException($"شناسه مشتری یافت نشد");
            }
            return 0;
        }

        private Guid? GetUserId()
        {
            try
            {
                return Guid.Parse(_httpContext.Request.Headers["x-userid"]);
            }
            catch
            {
                throw new AppException($"شناسه کاربر در هدر درخواست یافت نشد");
            }
        }

        public async Task<BaseResponse<GetPriceResponse>> GetPrice()
        {
            GetPriceResponse priceResponse = new();
            List<ServicePriceDto> prices = new();

            _courierCityMappings = await GetCourierCityMapping(_query.CourierCode, _query.SenderCityCode, _query.ReceiverCityCode);

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
                    SenderCity = _query.CourierCode,
                });

                if (_query.HasCollection)
                {
                    //priceResponse.CollectionPrices = collectionDistributionPrice.CollectionPrices;
                }
                if (_query.HasDistribution)
                {
                    //priceResponse.DistributionPrices = collectionDistributionPrice.DistributionPrices;
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
            var boxPrice = await _mediator.Send(new GetByCustomerAndBoxTypeContractBoxPriceQuery()
            {
                CustomerId = _customerId,
                CityId = _courierCityMappings.FirstOrDefault().CityId,
                ProvinceId = _courierCityMappings.FirstOrDefault().StateId,
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
            List<ContractValueAddedPriceDto> valueAddedPriceGetDtos = new();
            if (_query.ValueAddedIds != null && _query.ValueAddedIds.Any())
            {
                foreach (var item in _query.ValueAddedIds)
                {
                    var valueAddedPrice = await _mediator.Send(new GetByCustomerAndValueAddedContractValueAddedQuery()
                    {
                        CustomerId = _customerId,
                        CityId = _courierCityMappings.FirstOrDefault().CityId,
                        StateId = _courierCityMappings.FirstOrDefault().StateId,
                        ValueAddedId = item
                    });

                    valueAddedPriceGetDtos.Add(new ContractValueAddedPriceDto()
                    {
                        ContractId = valueAddedPrice.ContractId,
                        ContractValueAddedId = valueAddedPrice.ContractValueAddedId,
                        Name = valueAddedPrice.ValueAddedTypeName,
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
            List<ContractPriceDto> valueAddedPriceGetDtos = new();
            var insurancePrice = await _mediator.Send(new GetByCustomerAndValuePriceContractInsuranceQuery()
            {
                CustomerId = _customerId,
                CityId = _courierCityMappings.FirstOrDefault().CityId,
                ProvinceId = _courierCityMappings.FirstOrDefault().StateId,
                ValuePrice = _query.Value
            });

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

        private long PostChangePriceFormula(CourierCode courierCode, long price, long insurancePrice = 0)
        {
            var courier = _courierCityMappings.FirstOrDefault(x => x.Courier.Code == courierCode).Courier;
            if (courier == null)
            {
                return price;
            }
            else
            {
                double A = 20;// courier.DiscountPercent; // 20
                var B = price; // totalprice
                double C = insurancePrice;
                long D = 0; // courier.FixBasePrice;
                double E = 0;// courier.PriceHasTax ? B / 1.09 : B; // totalPrice : hastax = true ;
                double F = E - C - D;
                double G = 0;// courier.PriceHasDiscount ? 100 / (100 - A) * F : F;
                var I = 0; // courier.PostexPercent;
                var J = 0; // courier.PostexFixPrice;

                var X = (G + G * I / 100 + C + D) * 0.09 + J;

                return Convert.ToInt64(X);
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
            return await _mediator.Send(new GetPostShopIdQuery()
            {
                CityCode = cityCode,
            });
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
