﻿using MediatR;
using Postex.Product.Application.Dtos.CollectionDistributionPrices;
using Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket;
using Postex.Product.Application.Dtos.CollectionDistributionPrices.Helper;
using Postex.Product.Application.Features.CourierZones.Queries;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetCollectionPrices
{
    public class GetCollectionPricesQueryHandler : IRequestHandler<GetCollectionPricesQuery, PriceResponseDto>
    {
        private readonly IMediator _mediator;
        private GetCollectionPricesQuery _query;

        public GetCollectionPricesQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<PriceResponseDto> Handle(GetCollectionPricesQuery query, CancellationToken cancellationToken)
        {
            _query = query;
            return CalculateCollection(_query.Basket);
        }

        private PriceResponseDto CalculateCollection(BasketDto basket)
        {
            var validatePriceResponse = ValidateBasketSellPrice(basket);
            if (validatePriceResponse != null)
                return validatePriceResponse;

            var priceResponse = new PriceResponseDto
            {
                BasketId = basket.BasketId
            };

            decimal tempPriceIsNotNewCollection = 0;
            decimal priceDifferenceCollection = 0;

            //برسی اینکه همه بسته ها کنسل شده اند یا خیر
            if (basket.Parcels.All(x => x.IsCanceled == true))
            {
                priceDifferenceCollection = (decimal)((priceResponse?.CollectionPrice ?? 0) - tempPriceIsNotNewCollection -
                                                        basket.Parcels.Where(x => x.IsCanceled).Sum(x => x.CollectionPrice));
            }
            else
            {
                var basketNoCancel = new BasketDto()
                {
                    BasketId = basket.BasketId,
                    CourierCode = basket.CourierCode,
                    CityTypeCode = basket.CityTypeCode,
                    ServiceType = basket.ServiceType,
                    Parcels = basket.Parcels.Where(x => x.IsCanceled == false).ToList()
                };

                priceResponse = CalculateDistributionAndCollectionPrice(basketNoCancel);

                //اختلاف قیمت آیتم جدید سبد ارسالی با سبد فعلی  و آیتم هایی که قیلا کنسل شده اند

                var basketNotNewCancled = basket.Parcels.Where(x => x.IsNew == false && x.IsCanceled == false).ToList();

                tempPriceIsNotNewCollection = (decimal)basketNotNewCancled.Sum(x => x.CollectionPrice);

                priceDifferenceCollection =
                   (decimal)((priceResponse?.CollectionPrice ?? 0) - tempPriceIsNotNewCollection -
                              basket.Parcels.Where(x => x.IsCanceled).Sum(x => x.CollectionPrice));
            }


            //تقسیم هزینه مانده بین جعبه های جدید
            if (priceDifferenceCollection > 0)
            {
                if (basket.Parcels.Any(x => x.IsNew))
                {
                    var newParcelVolumeSum = basket.Parcels.Where(x => x.IsNew == true).Sum(x => x.GetVolume());

                    basket.Parcels.Where(x => x.IsNew == true).ToList()
                        .ForEach(x =>
                            x.CollectionPrice = priceDifferenceCollection *
                                                 ((decimal)x.GetVolume() / (decimal)newParcelVolumeSum));

                    priceResponse.CommentCollection =
                        $"( درسفارش های جدید اضافه شده است) از کیف پول یا درگاه کسر گردد {Math.Abs(priceDifferenceCollection)} ";
                    priceResponse.WalletCollection = priceDifferenceCollection;
                }
                else
                {
                    priceResponse.CommentCollection = $"از کیف پول یا درگاه کسر گردد {Math.Abs(priceDifferenceCollection)} ";
                    priceResponse.WalletCollection = priceDifferenceCollection;
                }
            }
            else if (priceDifferenceCollection < 0)
            {
                priceResponse.CommentCollection = $"به کیف پول اضافه گردد {Math.Abs(priceDifferenceCollection)} ";
                basket.Parcels.Where(x => x.IsNew == true).ToList().ForEach(x => x.CollectionPrice = 0);
                priceResponse.WalletCollection = priceDifferenceCollection;
            }
            else
            {
                priceResponse.CommentCollection = $"تراکنشی روی کیف پول نیاز نیست";
                priceResponse.WalletCollection = 0;
            }

            priceResponse.BoxSizes = basket.Parcels;
            priceResponse.CollectionPrice = priceResponse?.CollectionPrice ?? 0;

            //اگر بسته اول یا هر کدام از بسته های یک درخواست در سبد ارسالی نیاز به جمع آوری نداشت ، هزینه  جمع آوری سبد صفر است و جمع آوری با مشتری است
            if (basket.Parcels.Any(x => x.HasCollection == false))
            {
                priceResponse.CollectionPrice = 0;
                priceResponse.CommentCollection =
                    "چون اولین سفارش نیاز به جمع آوری  ندارد،این سفارش یا سفارشات به درخواست مشتری نیاز به جمع آوری ندارد";
            }
            return priceResponse;
        }

        private PriceResponseDto? ValidateBasketSellPrice(BasketDto basket)
        {
            foreach (var parcelsInBasket in basket.Parcels)
            {
                var byVolume = GetPriceByVolume(parcelsInBasket);

                if (byVolume != null)
                {
                    if (parcelsInBasket.CollectionPrice > byVolume.SellPrice)
                    {
                        PriceResponseDto priceResponse = new()
                        {
                            BasketId = basket.BasketId,
                            ErrorResponse = "قیمت جمع آوری بسته ارسالی از قیمت فروش آن بیشتراست. سبد را بازبینی کنید ",
                            CollectionPrice = null,
                            DistributionPrice = null,
                        };
                        return priceResponse;
                    }
                }
            }
            return null;
        }

        private BoxSizeDto? GetPriceByVolume(BoxPrice parcel)
        {
            var price = _query.CollectionDistributionPrices.Where(x =>
                x.CityType == parcel.DestinationCityType &&
                x.Volume >= parcel.GetVolume()).FirstOrDefault();

            if (price != null)
            {
                return new BoxSizeDto()
                {
                    BuyPrice = price.BuyPrice,
                    SellPrice = price.SellPrice,
                };
            }
            return null;
        }

        private CollectionDistributionPriceDto GetMaxVolume(BasketDto basket)
        {
            var price = _query.CollectionDistributionPrices.Where(x =>
               x.CityType == basket.CityTypeCode).LastOrDefault()!;
            return price;
        }

        private BoxSizeDto GetPriceByVolume(double volumeOfAllItemInBasket)
        {
            var price = _query.CollectionDistributionPrices.Where(x =>
                x.CityType == _query.Basket.CityTypeCode &&
                x.Volume >= volumeOfAllItemInBasket).FirstOrDefault();

            return new BoxSizeDto()
            {
                BuyPrice = price!.BuyPrice,
                SellPrice = price!.SellPrice,
            };
        }

        private async Task<decimal> GetCityTypeEntryPrice()
        {
            var cityTypes = await _mediator.Send(new GetCourierZonesQuery()
            {
                CityTypeCode = _query.Basket.CityTypeCode
            });
            if (cityTypes != null && cityTypes.Any())
            {
                return cityTypes.FirstOrDefault()!.EntryPrice;
            }
            return 0;
        }

        private PriceResponseDto CalculateDistributionAndCollectionPrice(BasketDto basket)
        {
            var response = new PriceResponseDto
            {
                BasketId = basket.BasketId
            };

            double volumeOfAllItemInBasket = basket.Parcels.Where(x => x.IsCanceled == false).Sum(x => x.GetVolume());
            decimal finalPriceCollection = 0;
            decimal finalPriceDistribution = 0;
            var maxVolumePrice = GetMaxVolume(basket);

            //محاسبه جمع آوری****************
            finalPriceCollection = CalculateCollection(basket, response, volumeOfAllItemInBasket, finalPriceCollection, maxVolumePrice, maxVolumePrice.Volume);
            //محاسبه توزیع****************
            finalPriceDistribution = CalculateDistribution(basket, response, finalPriceDistribution);

            return response;
        }

        private decimal CalculateCollection(BasketDto basket, PriceResponseDto response, double volumeOfAllItemInBasket, decimal finalPriceCollection, CollectionDistributionPriceDto maxVolumePrice, double maxVolume)
        {
            if (volumeOfAllItemInBasket >= maxVolume)
            {
                int numberOfMaxSizeInBasket = (int)volumeOfAllItemInBasket / (int)maxVolume;
                double restOfBoxVolume = volumeOfAllItemInBasket % maxVolume;
                decimal numberOfMaxSizeInBasketPrice = numberOfMaxSizeInBasket * maxVolumePrice.SellPrice;
                var restOfBox = GetPriceByVolume(restOfBoxVolume);
                decimal restOfBoxInBasketPrice = 0;
                if (restOfBox != null)
                {
                    restOfBoxInBasketPrice = restOfBox.SellPrice;
                }

                finalPriceCollection = numberOfMaxSizeInBasketPrice + restOfBoxInBasketPrice;
                //اضافه کردن جعبه های ماکزیمم  به لیست

                for (int i = 0; i < numberOfMaxSizeInBasket; i++)
                {
                    var boxSize = new BoxPrice
                    {
                        SellPrice = maxVolumePrice.SellPrice,
                        BuyPrice = maxVolumePrice.BuyPrice,
                        SizeOfBox = maxVolumePrice.Volume.ToString("##,###")
                    };
                    response.BoxSizes.Add(boxSize);
                }

                //اگر باقیمانده حجم جعبه پس از کسر سایز ماکزیمم صفر نبودآنرا به لیست جعبه ها و نزدیکترین سایز  اضافه می کنیم
                if (restOfBox != null)
                {
                    response.BoxSizes.Add(new BoxPrice()
                    {
                        BuyPrice = restOfBox.BuyPrice,
                        SellPrice = restOfBox.SellPrice
                    });
                }
            }
            //چنانچه حجم کل جعبه ها به  ماکزیمم  نرسید و کمتر از آن بود به نزدیک ترین جعبه تبدیل می کنیم 
            else
            {
                var volume = GetPriceByVolume(volumeOfAllItemInBasket);
                var restOfBox = new BoxPrice()
                {
                    BuyPrice = volume.BuyPrice,
                    SellPrice = volume.SellPrice,
                };
                if (restOfBox != null)
                {
                    finalPriceCollection = restOfBox.SellPrice;
                    response.BoxSizes.Add(restOfBox);
                }
            }

            //  مجانی شدن جمع آوری برای 10 بسته در هر سبد سفارش برای پیکهاب ، لینک اکپرس ، اسپید و تعارف
            if (basket.Parcels.Count >= 10 && (basket.CourierCode == CourierCode.Paykhub ||
                                               basket.CourierCode == CourierCode.Taroff ||
                                               basket.CourierCode == CourierCode.Link ||
                                               basket.CourierCode == CourierCode.Speed ||
                                               basket.CourierCode == CourierCode.PishroPost))
            {
                response.CollectionPrice = 0;
            }
            else
            {
                response.CollectionPrice = finalPriceCollection;
            }
            //اگر بسته اول یا هر کدام از بسته های یک درخواست در سبد ارسالی نیاز به جمع آوری نداشت ، هزینه  جمع آوری سبد صفر است و جمع آوری با مشتری است
            if (basket.Parcels.Any(x => x.HasCollection == false))
            {
                response.CollectionPrice = 0;
                response.CommentCollection =
                    "چون اولین سفارش نیاز به توزیه ندارد،این سفارش یا سفارشات به درخواست مشتری نیاز به توزیع ندارد";
            }

            return finalPriceCollection;
        }

        private decimal CalculateDistribution(BasketDto basket, PriceResponseDto response, decimal finalPriceDistribution)
        {
            for (int i = 0; i < basket.Parcels.Count; i++)
            {
                var byVolume = GetPriceByVolume(basket.Parcels[i].GetVolume());
                finalPriceDistribution += byVolume.SellPrice;
            }

            response.DistributionPrice = finalPriceDistribution;
            //اگر بسته اول یا هر کدام از بسته های یک درخواست در سبد ارسالی نیاز به توزیع نداشت ، هزینه  توزیع سبد صفر است و توزیع با مشتری است

            if (basket.Parcels.Any(x => x.HasDistribution == false))
            {
                response.DistributionPrice = 0;
                response.CommentDistribution =
                    "چون اولین سفارش نیاز به توزیه ندارد،این سفارش یا سفارشات به درخواست مشتری نیاز به توزیع ندارد";
            }

            return finalPriceDistribution;
        }
    }
}
