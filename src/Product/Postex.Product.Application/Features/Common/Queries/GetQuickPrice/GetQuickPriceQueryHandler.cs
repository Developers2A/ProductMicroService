using MediatR;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Dtos.ServiceProviders.Mahex.Common;
using Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByUserAndBoxType;
using Postex.Product.Application.Features.CourierCityMappings.Queries;
using Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetPeykOfflinePrices;
using Postex.Product.Application.Features.PostShops.Queries;
using Postex.Product.Application.Features.ServiceProviders.Chapar.Queries.GetPrice;
using Postex.Product.Application.Features.ServiceProviders.Kbk.Queries.GetPrice;
using Postex.Product.Application.Features.ServiceProviders.Mahex.Queries.GetPrice;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetPrice;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.Common.Queries.GetQuickPrice
{
    public class GetQuickPriceQueryHandler : IRequestHandler<GetQuickPriceQuery, BaseResponse<GetQuickPriceResponse>>
    {
        private readonly IMediator _mediator;
        private List<CourierCityMappingDto> _courierCityMappings;
        private GetQuickPriceQuery _query;

        public GetQuickPriceQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<GetQuickPriceResponse>> Handle(GetQuickPriceQuery request, CancellationToken cancellationToken)
        {
            return await GetQuickPrice(request);
        }

        public async Task<BaseResponse<GetQuickPriceResponse>> GetQuickPrice(GetQuickPriceQuery query)
        {
            _query = query;
            GetQuickPriceResponse priceResponse = new();
            List<ServicePrice> prices = new();

            //TODO : read from contract value added
            //await ValueAddedPrice(priceResponse, request);

            _courierCityMappings = await GetCourierCityMapping(query.CourierCode, query.SenderCityCode, query.ReceiverCityCode);

            if (query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Kalaresan || query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.All)
            {
                var kbkResponse = await KbkPrice(query);
                if (kbkResponse != null)
                {
                    prices.Add(kbkResponse);
                }
            }

            if (query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Mahex || query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.All)
            {
                var mahexResponse = await MahexPrice(query);
                if (mahexResponse != null)
                {
                    prices.Add(mahexResponse);
                }
            }

            if (query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Chapar || query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.All)
            {
                var chaparResponse = await ChaparPrice(query);
                if (chaparResponse != default)
                {
                    prices.AddRange(chaparResponse);
                }
            }

            if (query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Post || query.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.All)
            {
                var postResponse = await PostPrice(query);
                if (postResponse != default)
                {
                    prices.AddRange(postResponse);
                }
            }

            if (query.HasCollection || query.HasDistribution)
            {
                var collectionDistributionPrice = await _mediator.Send(new GetPeykOfflinePricesQuery()
                {
                    CourierCode = query.CourierCode,
                    SenderCityCode = query.SenderCityCode,
                });

                if (query.HasCollection)
                {
                    priceResponse.CollectionPrices = collectionDistributionPrice.CollectionPrices;
                }
                if (query.HasDistribution)
                {
                    priceResponse.DistributionPrices = collectionDistributionPrice.DistributionPrices;
                }
            }

            priceResponse.ServicePrices = prices;

            return new(true, "success", priceResponse); ;
        }

        private async Task GetBoxPrice()
        {
            var boxPrice = await _mediator.Send(new GetByUserAndBoxTypeContractBoxPriceQuery()
            {
                BoxTypeId = _query.BoxTypeId
            });
        }

        //private async Task ValueAddedPrice(GetPriceResponse priceResponse, GetPriceQuery request)
        //{
        //    if (request.Avatar || request.Sms || request.Print)
        //    {
        //        var valueAddedPrices = await _mediator.Send(new GetValueAddedPricesQuery());
        //        if (valueAddedPrices.Any())
        //        {
        //            var avatarPrice = valueAddedPrices.FirstOrDefault(/*x => x.ValueAddedType == ValueAddedType.Avatar*/);
        //            var smsPrice = valueAddedPrices.FirstOrDefault(/*x => x.ValueAddedType == ValueAddedType.Sms*/);
        //            var printPrice = valueAddedPrices.FirstOrDefault(/*x => x.ValueAddedType == ValueAddedType.Print*/);

        //            if (request.Avatar && avatarPrice != null)
        //            {
        //                priceResponse.AvatarPrice = avatarPrice.SellPrice;
        //            }
        //            if (request.Sms && smsPrice != null)
        //            {
        //                priceResponse.SmsPrice = smsPrice.SellPrice;
        //            }
        //            if (request.Print && printPrice != null)
        //            {
        //                priceResponse.PrintPrice = printPrice.SellPrice;
        //            }
        //        }
        //    }
        //}

        public async Task<List<CourierCityMappingDto>> GetCourierCityMapping(int courierCode, int senderCity, int receiverCity)
        {
            return await _mediator.Send(new GetCourierCityMappingsByCourierAndCitiesQuery()
            {
                CourierCode = courierCode,
                CityCodes = new List<int> { senderCity, receiverCity }
            });
        }

        public async Task<ServicePrice> KbkPrice(GetQuickPriceQuery request)
        {
            string senderCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Kalaresan, request.SenderCityCode);
            string receiverCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Kalaresan, request.ReceiverCityCode);

            var priceRequest = new GetKbkPriceQuery()
            {
                DestinationCity = int.Parse(receiverCityCode),
                OriginCity = int.Parse(senderCityCode),
                Detail = new List<KbkPriceDetailsRequest>()
                {
                    new()
                    {
                        Count = 1,
                        Size = request.Weight
                    }
                }
            };

            var result = await _mediator.Send(priceRequest);
            if (result.IsSuccess)
            {
                return new ServicePrice()
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

        private long PostChangePriceFormula(SharedKernel.Common.Enums.CourierCode courierCode, long price, long insurancePrice = 0)
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


        private string GetCityMappedCode(SharedKernel.Common.Enums.CourierCode courierCode, int cityCode)
        {
            var city = _courierCityMappings.FirstOrDefault(x => x.Courier.Code == courierCode && x.Code == cityCode);
            if (city == null)
            {
                return "0";
            }
            return city.MappedCode;
        }

        public async Task<ServicePrice> MahexPrice(GetQuickPriceQuery request)
        {
            string senderCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Mahex, request.SenderCityCode);
            string receiverCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Mahex, request.ReceiverCityCode);

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
                        Weight = (decimal)request.Weight / 1000,
                        DeclaredValue = request.Value
                    }
                }
            };

            var result = await _mediator.Send(priceRequest);
            if (result.IsSuccess)
            {
                return new ServicePrice()
                {
                    PostexPrice = ChangePrice(SharedKernel.Common.Enums.CourierCode.Mahex, Convert.ToInt64(result.Data.Data.Rate.Amount)),
                    CourierName = "ماهکس",
                    CourierCode = (int)SharedKernel.Common.Enums.CourierCode.Mahex
                };
            }
            return null;
        }

        public async Task<List<ServicePrice>> ChaparPrice(GetQuickPriceQuery request)
        {
            List<ServicePrice> priceResult = new();
            string senderCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Chapar, request.SenderCityCode);
            string receiverCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Chapar, request.ReceiverCityCode);
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
                        Weight = (decimal)request.Weight / 1000,
                        Value = request.Value,
                        Origin = senderCityCode,
                        Destination = receiverCityCode,
                        Method = method
                    }
                };

                var result = await _mediator.Send(priceRequest);
                if (result.IsSuccess)
                {
                    if (result.Data == null) continue;
                    priceResult.Add(new ServicePrice()
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

        public async Task<List<ServicePrice>> PostPrice(GetQuickPriceQuery request)
        {
            List<ServicePrice> priceResult = new();
            string senderCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Post, request.SenderCityCode);
            string receiverCityCode = GetCityMappedCode(SharedKernel.Common.Enums.CourierCode.Post, request.ReceiverCityCode);
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
                    Weight = request.Weight,
                    ParcelValue = request.Value
                };

                var result = await _mediator.Send(priceRequest);
                if (result.IsSuccess)
                {
                    if (result.Data == null) continue;
                    var servicePrice = new ServicePrice()
                    {
                        PostexPrice = Convert.ToInt64(result.Data.PostPrice),
                        PostexTax = Convert.ToInt64(result.Data.DiscountAmount * 0.09),
                        TotalPrice = Convert.ToInt64(result.Data.PostPrice * 1.09),
                        CourierTax = result.Data.Tax,
                        CourierName = courier,
                        CourierCode = (int)SharedKernel.Common.Enums.CourierCode.Post,
                        DiscountAmount = result.Data.DiscountAmount,

                    };
                    priceResult.Add(servicePrice);
                }
            }
            return priceResult;
        }
    }
}
