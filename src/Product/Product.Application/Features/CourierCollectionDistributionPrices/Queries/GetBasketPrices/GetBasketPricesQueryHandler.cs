using MediatR;
using Microsoft.EntityFrameworkCore;
using ParcelPriceCalculatorPaykhub.Helper;
using ParcelPriceCalculatorPaykhub.Models.ViewModels;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Commons;
using Product.Application.Dtos.CourierServices.Common;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierCityTypePrices.Queries.GetBasketPrices
{
    public class GetBasketPricesQueryHandler : IRequestHandler<GetBasketPricesQuery, GetPriceResponse>
    {
        private readonly IReadRepository<CourierZoneCollectionDistributionPrice> _readRepository;
        private readonly IMediator _mediator;
        private List<CityDto> _cities;
        private List<CourierZoneCollectionDistributionPrice> _courierZoneCollectionDistributionPrice;
        private GetBasketPricesQuery _query;

        public GetBasketPricesQueryHandler(
            IReadRepository<CourierZoneCollectionDistributionPrice> readRepository,
            IMediator mediator)
        {
            _readRepository = readRepository;
            _mediator = mediator;
        }

        public async Task<GetPriceResponse> Handle(GetBasketPricesQuery request, CancellationToken cancellationToken)
        {
            _courierZoneCollectionDistributionPrice =
                await _readRepository.TableNoTracking.Include(x => x.CourierZone)
                .ThenInclude(x => x.Courier)
                .Where(x => x.CourierZone.Courier.Code == request.CourierId).ToListAsync();

            _query = request;
            GetPriceResponse response = new();
            response.ServicePrices = new();
            //_cities = await GetCities();
            //_courierZoneCityMappings = await GetCourierZoneCityMappings();


            return response;
        }

        public async Task<CollectionDistributionPriceResponse> CalculateSwitch(GetBasketPricesQuery basket)
        {
            var response = new CollectionDistributionPriceResponse
            {
                BasketId = basket.BasketId
            };
            // کوریر منتخب امکان جمع آوری و یا توزیع ندارد
            int courierIdInBasket = (int)basket.CourierId.GetHashCode();
            if (_courierZoneCollectionDistributionPrice == null || !_courierZoneCollectionDistributionPrice.Any())
            {
                response.ErrorResponse = "کوریر منتخب امکان جمع آوری و یا توزیع ندارد ";
                response.CollectionPrice = null;
                response.DistributionPrice = null;
                return response;
            }
            //  کوریر امکان جمع آوری و توزیع سایز درخواستی را ندارد 
            var maxBoxSize = _courierZoneCollectionDistributionPrice
                .OrderBy(ParcelCities => ParcelCities.Volume).Last().Volume;
            foreach (var parcelsInBasket in basket.Parcels)
            {
                if ((int)parcelsInBasket.GetVolume() > (int)maxBoxSize)
                {
                    response.ErrorResponse = "کوریر امکان جمع آوری و توزیع سایز درخواستی را ندارد  ";
                    response.CollectionPrice = null;
                    response.DistributionPrice = null;
                    return response;
                }
            }

            //  کوریر در شهر درخواستی سرویس نمی دهد
            for (int i = 0; i < basket.Parcels.Count; i++)
            {
                //if (!_courierZoneCollectionDistributionPrice.
                //    Any(x => x.CourierZone.CityType == (int)basket.Parcels[i].DestinationCityTypeId))
                //    {
                //        response.ErrorResponse = "کوریر در شهر درخواستی سرویس نمی دهد ";
                //        response.CollectionPrice = null;
                //        response.DistributionPrice = null;
                //        return response;
                //    }
            }
            //if (!_cachedData.GetAllParcels().Any(x => x.CityType == (int)basket.CityTypeId &&
            //                                                     x.CourierType == (int)basket.CourierId))
            //{
            //    response.ErrorResponse = "کوریر در شهر درخواستی سرویس نمی دهد ";
            //    response.CollectionPrice = null;
            //    response.DistributionPrice = null;
            //    return response;
            //}
            //برسی خالی نبودن یا نال نبودن لیست درخواستی 

            if (!basket.Parcels.Any())
            {
                response.ErrorResponse = "درخواست شما خالی است، لطفا بسته هارا  اضافه کنید ";
                response.CollectionPrice = null;
                response.DistributionPrice = null;
                return response;
            }
            //برسی سفارش اگر هم جدید باشد و هم کنسلی
            if (basket.Parcels.Any(x => x.IsCanceled == true && x.IsNew == true))
            {
                response.ErrorResponse = "بسته نمی تواند هم جدید و هم کنسلی باشد ";
                response.CollectionPrice = null;
                response.DistributionPrice = null;
                return response;
            }
            //بسته جدید قیمت جمع اوری دارد

            if (basket.Parcels.Any(x => x.IsNew == true && x.CollectionPrice > 0))
            {
                response.ErrorResponse = "بسته جدید نباید قیمت جمع آوری داشته باشد ";
                response.CollectionPrice = null;
                response.DistributionPrice = null;
                return response;
            }
            //بسته جدید قیمت توزیع دارد
            if (basket.Parcels.Any(x => x.IsNew == true && x.DistributionPrice > 0))
            {
                response.ErrorResponse = "بسته جدید نباید قیمت توزیع داشته باشد ";
                response.CollectionPrice = null;
                response.DistributionPrice = null;
                return response;
            }

            switch (basket.ServiceId)
            {
                case ServiceType.DistributionAndCollectionService:
                    return await CalculateCollectionDistribution(basket, response);
                case ServiceType.CollectionService:
                    return await CalculateCollection(basket, response);
                case ServiceType.DistributionService:
                    return await CalculateDistribution(basket, response);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        //******توزیع و جمع آوری ***********
        // برای API با امکان ارسال تجمیعی و تکی  سبد 
        private async Task<CollectionDistributionPriceResponse> CalculateCollectionDistribution(GetBasketPricesQuery basket, CollectionDistributionPriceResponse response)
        {


            var priceResponse = await CalculateCollection(basket, response);


            priceResponse = await CalculateDistribution(basket, priceResponse);


            return priceResponse;
        }
        //******  جمع آوری ***********

        private async Task<CollectionDistributionPriceResponse> CalculateCollection(GetBasketPricesQuery basket, CollectionDistributionPriceResponse priceResponse)
        {
            //برسی اینکه قیمت جمع اوری بسته ارسالی بیشتر از قیمت فروش نباشد 
            foreach (var parcelsInBasket in basket.Parcels)
            {
                var byVolume = await _mediator.Send(new GetParcelCitiesByVolumAndCityTypeQuery()
                {
                    CityType = parcelsInBasket.DestinationCityTypeId,
                    Volume = parcelsInBasket.GetVolume()
                });
                if (parcelsInBasket.CollectionPrice > byVolume.SellPrice)
                {
                    priceResponse.ErrorResponse = "قیمت جمع آوری بسته ارسالی از قیمت  جمع آوری آن بیشتراست. سبد را بازبینی کنید ";
                    priceResponse.CollectionPrice = null;
                    priceResponse.DistributionPrice = null;
                    return priceResponse;
                }
            }

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

                //var basketNoCancel = basket.Adapt<Basket>();
                //basketNoCancel.Parcels = basket.Parcels.Where(x => x.IsCanceled == false).ToList();

                priceResponse = await CalculateDistributionAndCollectionPrice(basket);


                //اختلاف قیمت آیتم جدید سبد ارسالی با سبد فعلی  و آیتم هایی که قیلا کنسل شده اند

                var basketNotNewCancled = basket.Parcels.Where(x => x.IsNew == false && x.IsCanceled == false).ToList();

                tempPriceIsNotNewCollection = (decimal)basketNotNewCancled.Sum(x => x.CollectionPrice);

                priceDifferenceCollection =
                   (decimal)((priceResponse?.CollectionPrice ?? 0) - tempPriceIsNotNewCollection -
                              basket.Parcels.Where(x => x.IsCanceled).Sum(x => x.CollectionPrice));
            }


            //تقسیم هزینه مانده بین   جعبه های جدید
            if (priceDifferenceCollection > 0)
            {
                if (basket.Parcels.Any(x => x.IsNew))
                {
                    var newParcelVolumeSum = basket.Parcels.Where(x => x.IsNew == true).Sum(x => x.GetVolume());

                    basket.Parcels.Where(x => x.IsNew == true).ToList()
                        .ForEach(x =>
                            x.CollectionPrice = (priceDifferenceCollection *
                                                 ((decimal)x.GetVolume() / (decimal)newParcelVolumeSum)));

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
            if (basket.Parcels.Any(x => x.NeedsCollection == false))
            {
                priceResponse.CollectionPrice = 0;
                priceResponse.CommentCollection =
                    "چون اولین سفارش نیاز به جمع آوری  ندارد،این سفارش یا سفارشات به درخواست مشتری نیاز به جمع آوری ندارد";

            }
            return priceResponse;
        }

        //******  توزیع ***********

        private async Task<CollectionDistributionPriceResponse> CalculateDistribution(GetBasketPricesQuery basket, CollectionDistributionPriceResponse priceResponse)
        {
            //برسی اینکه قیمت جمع اوری بسته ارسالی بیشتر از قیمت فروش نباشد 

            foreach (var parcelsInBasket in basket.Parcels)
            {
                var byVolume = await _mediator.Send(new GetParcelCitiesByVolumAndCityTypeQuery()
                {
                    CityType = parcelsInBasket.DestinationCityTypeId,
                    Volume = parcelsInBasket.GetVolume()
                });
                //_parcelCityService.GetByVolume(parcelsInBasket.GetVolume(), (int)parcelsInBasket.DestinationCityTypeId, (int)basket.CourierId);
                if (parcelsInBasket.DistributionPrice > byVolume.SellPrice)
                {
                    priceResponse.ErrorResponse = "قیمت توزیع بسته ارسالی از قیمت فروش آن بیشتراست. سبد را بازبینی کنید ";
                    priceResponse.CollectionPrice = null;
                    priceResponse.DistributionPrice = null;
                    return priceResponse;
                }
            }
            //var basketNoCancel = basket.Adapt<Basket>();
            //basketNoCancel.Parcels = basket.Parcels.Where(x => x.IsCanceled == false).ToList();
            //محاسبه بسته جدید، کنسلی و نیازمند به جمع آوری در سبد

            foreach (var parcelsInBasket in basket.Parcels)
            {
                if (parcelsInBasket.IsNew && !parcelsInBasket.IsCanceled)
                {
                    var byVolume = await _mediator.Send(new GetParcelCitiesByVolumAndCityTypeQuery()
                    {
                        CityType = parcelsInBasket.DestinationCityTypeId,
                        Volume = parcelsInBasket.GetVolume()
                    });
                    //var byVolume = _parcelCityService.GetByVolume(parcelsInBasket.GetVolume(), (int)parcelsInBasket.DestinationCityTypeId, (int)basket.CourierId);
                    parcelsInBasket.DistributionPrice = byVolume.SellPrice;
                    parcelsInBasket.BuyingPrice = byVolume.BuyPrice;
                    parcelsInBasket.SellingPrice = byVolume.SellPrice;
                    //اگر بسته  یا هر کدام از بسته های یک درخواست در سبد ارسالی نیاز به توزیع نداشت ، هزینه  توزیع سبد صفر است و توزیع با مشتری است


                }
                if (parcelsInBasket.NeedsDistribution == false)
                {
                    parcelsInBasket.DistributionPrice = 0;
                }
            }
            //جعبه های که کنسل نشده و جدیدنیستند- جعبه های از قبل محاسبه شده
            var basketNotNewCancled = basket.Parcels.Where(x => x.IsNew == false && x.IsCanceled == false).ToList();

            //اختلاف قیمت سبد ارسالی با ای پی آی و آیتم هایی که قیلا محاسبه شده اند
            var tempPriceIsNotNewCanceldDistribution = basketNotNewCancled.Sum(x => x.DistributionPrice);

            var priceDifferenceDistribution = basket.Parcels.Where(x => !x.IsCanceled).Sum(x => x.DistributionPrice) - tempPriceIsNotNewCanceldDistribution - basket.Parcels.Where(x => x.IsCanceled).Sum(x => x.DistributionPrice);

            //تقسیم هزینه مانده بین   جعبه های جدید
            if (priceDifferenceDistribution > 0)
            {
                priceResponse.CommentDistribution = $"از کیف پول یا درگاه کسر گردد {Math.Abs((decimal)priceDifferenceDistribution)} ";
                priceResponse.WalletDistribution = (decimal)priceDifferenceDistribution;

            }
            else if (priceDifferenceDistribution < 0)
            {
                priceResponse.CommentDistribution = $"به کیف پول اضافه گردد {Math.Abs((decimal)priceDifferenceDistribution)} ";
                priceResponse.WalletDistribution = (decimal)priceDifferenceDistribution;

            }
            else
            {
                priceResponse.CommentDistribution = $"تراکنشی روی کیف پول نیاز نیست";
                priceResponse.WalletDistribution = 0;
            }

            priceResponse.BoxSizes = basket.Parcels;
            priceResponse.DistributionPrice = basket.Parcels.Where(x => !x.IsCanceled).Sum(x => x.DistributionPrice);
            return priceResponse;
        }

        /// روش توزیع و جمع آوری  
        private async Task<CollectionDistributionPriceResponse> CalculateDistributionAndCollectionPrice(GetBasketPricesQuery basket)
        {
            //برسی خالی نبودن یا نال نبودن لیست درخواستی 

            if (!basket.Parcels.Any())
            {
                return null;
            }



            // var cityType = _cachedData.GetTypeOfCities().SingleOrDefault(x => x.Id == (int)basket.CityTypeId);

            var response = new CollectionDistributionPriceResponse
            {
                BasketId = basket.BasketId
            };
            double volumeOfAllItemInBasket = basket.Parcels.Where(x => x.IsCanceled == false).Sum(x => x.GetVolume());
            decimal finalPriceCollection = 0;
            decimal finalPriceDistribution = 0;
            var cityTypeId = (int)basket.CityTypeId;
            var CourierId = (int)basket.CourierId;




            var maxParcelCities = await _mediator.Send(new GetMaxParcelCityQuery()
            {
                CityType = (CityTypeCode)cityTypeId,
            });

            var maxVolume = maxParcelCities.Volume;
            //محاسبه جمع آوری****************
            if (volumeOfAllItemInBasket >= maxVolume)
            {
                int numberOfMaxSizeInBasket = (int)volumeOfAllItemInBasket / (int)maxVolume;
                double restOfBoxVolume = volumeOfAllItemInBasket % maxVolume;
                decimal numberOfMaxSizeInBasketPrice = numberOfMaxSizeInBasket * maxParcelCities.SellPrice;
                var restOfBox =
                    await _mediator.Send(new GetParcelCitiesByVolumAndCityTypeQuery()
                    {
                        CityType = (CityTypeCode)cityTypeId,
                        Volume = restOfBoxVolume
                    });
                //_parcelCityService.GetByVolume(restOfBoxVolume, cityTypeId, CourierId).Adapt<BoxPrice>();
                decimal restOfBoxInBasketPrice = 0;
                if (restOfBox != null)
                {
                    restOfBoxInBasketPrice = restOfBox.SellPrice;
                }

                finalPriceCollection = numberOfMaxSizeInBasketPrice + restOfBoxInBasketPrice;
                //اضافه کردن جعبه های ماکزیمم  به لیست

                for (int i = 0; i < numberOfMaxSizeInBasket; i++)
                {
                    // var boxSize = maxParcelCities.Adapt<BoxPrice>();
                    // boxSize.SizeOfBox = maxParcelCities.Volume.ToString("##,###");
                    // response.BoxSizes.Add(boxSize);
                }

                //اگر باقیمانده حجم جعبه پس از کسر سایز ماکزیمم صفر نبودآنرا به لیست جعبه ها و نزدیکترین سایز  اضافه می کنیم
                if (restOfBox != null)
                {
                    //response.BoxSizes.Add(restOfBox);
                }
            }
            //چنانچه حجم کل جعبه ها به  ماکزیمم  نرسید و کمتر از آن بود به نزدیک ترین جعبه تبدیل می کنیم 
            else
            {
                var restOfBox = await _mediator.Send(new GetParcelCitiesByVolumAndCityTypeQuery()
                {
                    CityType = (CityTypeCode)cityTypeId,
                    Volume = volumeOfAllItemInBasket
                });
                //_parcelCityService.GetByVolume(volumeOfAllItemInBasket, cityTypeId, CourierId).Adapt<BoxPrice>();
                if (restOfBox != null)
                {
                    finalPriceCollection = restOfBox.SellPrice;
                    //if (cityType.EntryPrice > finalPriceCollection)
                    //{
                    //    finalPriceCollection = cityType.EntryPrice;
                    //}

                    //response.BoxSizes.Add(restOfBox);
                }
            }

            //  مجانی شدن جمع آوری برای 10 بسته در هر سبد سفارش برای پیکهاب ، لینک اکپرس ، اسپیدو تعارف
            if (basket.Parcels.Count >= 10 && (basket.CourierId == CourierCode.Paykhub ||
                                               basket.CourierId == CourierCode.Taroff ||
                                               basket.CourierId == CourierCode.Link ||
                                               basket.CourierId == CourierCode.Speed || basket.CourierId == CourierCode.PishroPost))
            {
                response.CollectionPrice = 0;
            }
            else
            {
                response.CollectionPrice = finalPriceCollection;
            }
            //اگر بسته اول یا هر کدام از بسته های یک درخواست در سبد ارسالی نیاز به جمع آوری نداشت ، هزینه  جمع آوری سبد صفر است و جمع آوری با مشتری است
            if (basket.Parcels.Any(x => x.NeedsCollection == false))
            {
                response.CollectionPrice = 0;
                response.CommentCollection =
                    "چون اولین سفارش نیاز به توزیه ندارد،این سفارش یا سفارشات به درخواست مشتری نیاز به توزیع ندارد";

            }
            //محاسبه توزیع****************
            for (int i = 0; i < basket.Parcels.Count; i++)
            {
                var byVolume = await _mediator.Send(new GetParcelCitiesByVolumAndCityTypeQuery()
                {
                    CityType = (CityTypeCode)cityTypeId,
                    Volume = basket.Parcels[i].GetVolume()
                });
                finalPriceDistribution += byVolume.SellPrice;
            }

            response.DistributionPrice = finalPriceDistribution;
            //اگر بسته اول یا هر کدام از بسته های یک درخواست در سبد ارسالی نیاز به توزیع نداشت ، هزینه  توزیع سبد صفر است و توزیع با مشتری است

            if (basket.Parcels.Any(x => x.NeedsDistribution == false))
            {
                response.DistributionPrice = 0;
                response.CommentDistribution =
                    "چون اولین سفارش نیاز به توزیه ندارد،این سفارش یا سفارشات به درخواست مشتری نیاز به توزیع ندارد";
            }

            return response;
        }


        /// جمع آوری 
        private async Task<CollectionDistributionPriceResponse> CalculateCollectionPrice(GetBasketPricesQuery basket)
        {
            //برسی خالی نبودن یا نال نبودن لیست درخواستی 
            if (!basket.Parcels.Any())
            {
                return null;
            }

            //محاسبه جمع آوری
            var response = new CollectionDistributionPriceResponse
            {
                BasketId = basket.BasketId
            };
            //var cityType = _cachedData.GetTypeOfCities().SingleOrDefault(x => x.Id == (int)basket.CityTypeId);

            double volumeOfAllItemInBasket = basket.Parcels.Sum(x => x.GetVolume());
            decimal finalPrice = 0;
            var cityTypeId = (int)basket.CityTypeId;
            var CourierId = (int)basket.CourierId;
            var maxParcelCities = await _mediator.Send(new GetMaxParcelCityQuery()
            {
                CityType = (CityTypeCode)cityTypeId
            });
            var maxVolume = maxParcelCities.Volume;

            if (volumeOfAllItemInBasket >= maxVolume)
            {
                int numberOfMaxSizeInBasket = (int)volumeOfAllItemInBasket / (int)maxVolume;
                double restOfBoxVolume = volumeOfAllItemInBasket % maxVolume;
                decimal numberOfMaxSizeInBasketPrice = numberOfMaxSizeInBasket * maxParcelCities.SellPrice;
                var restOfBox = await _mediator.Send(new GetParcelCitiesByVolumAndCityTypeQuery()
                {
                    CityType = (CityTypeCode)cityTypeId,
                    Volume = restOfBoxVolume
                });
                //_parcelCityService.GetByVolume(restOfBoxVolume, cityTypeId, CourierId).Adapt<BoxPrice>();
                decimal restOfBoxInBasketPrice = 0;
                if (restOfBox != null)
                {
                    restOfBoxInBasketPrice = restOfBox.SellPrice;
                }


                finalPrice = numberOfMaxSizeInBasketPrice + restOfBoxInBasketPrice;
                //اضافه کردن جعبه های ماکزیمم به لیست

                for (int i = 0; i < numberOfMaxSizeInBasket; i++)
                {
                    //var boxSize = maxParcelCities.Adapt<BoxPrice>();
                    //boxSize.SizeOfBox = maxParcelCities.Volume.ToString("##,###");
                    //response.BoxSizes.Add(boxSize);
                }

                //اگر باقیمانده حجم جعبه پس از کسر سایز ماکزیمم صفر نبودآنرا به لیست جعبه ها و نزدیکترین سایز  اضافه می کنیم
                if (restOfBox != null)
                {
                    //response.BoxSizes.Add(restOfBox);
                }
            }
            //چنانچه حجم کل جعبه ها به  ماکزیمم یا همان 9 نرسید و کمتر از آن بود به نزدیک ترین جعبه تبدیل می کنیم 
            else
            {
                var restOfBox =
                    await _mediator.Send(new GetParcelCitiesByVolumAndCityTypeQuery()
                    {
                        CityType = (CityTypeCode)cityTypeId,
                        Volume = volumeOfAllItemInBasket
                    });
                //_parcelCityService.GetByVolume(volumeOfAllItemInBasket, cityTypeId, CourierId).Adapt<BoxPrice>();
                if (restOfBox != null)
                {
                    finalPrice = restOfBox.SellPrice;
                    //if (cityType.EntryPrice > finalPrice)
                    //{
                    //finalPrice = cityType.EntryPrice;
                    //}/

                    //response.BoxSizes.Add(restOfBox);
                }
            }

            response.CollectionPrice = finalPrice;
            //اگر بسته اول یا هر کدام از بسته های یک درخواست در سبد ارسالی نیاز به جمع آوری نداشت ، هزینه  جمع آوری سبد صفر است و جمع آوری با مشتری است
            if (basket.Parcels.Any(x => x.NeedsCollection == false))
            {
                response.CollectionPrice = 0;
                response.CommentCollection =
                    "چون اولین سفارش نیاز به توزیه ندارد،این سفارش یا سفارشات به درخواست مشتری نیاز به توزیع ندارد";

            }

            return response;
        }


        /// محاسبه توزیع
        private async Task<CollectionDistributionPriceResponse> CalculateDistributionPrice(GetBasketPricesQuery basket)
        {
            //برسی خالی نبودن یا نال نبودن لیست درخواستی 
            if (!basket.Parcels.Any())
            {
                return null;
            }

            var response = new CollectionDistributionPriceResponse
            {
                BasketId = basket.BasketId
            };
            decimal finalPriceDistribution = 0;
            var cityTypeId = (int)basket.CityTypeId;
            var CourierId = (int)basket.CourierId;
            response.CollectionPrice = 0;
            //محاسبه جمع آوری 
            foreach (var parcelsInBasket in basket.Parcels)
            {
                var byVolume = await _mediator.Send(new GetParcelCitiesByVolumAndCityTypeQuery()
                {
                    CityType = parcelsInBasket.DestinationCityTypeId,
                    Volume = parcelsInBasket.GetVolume()
                });
                finalPriceDistribution += byVolume.SellPrice;
            }

            response.DistributionPrice = finalPriceDistribution;

            //اگر بسته اول یا هر کدام از بسته های یک درخواست در سبد ارسالی نیاز به توزیع نداشت ، هزینه  توزیع سبد صفر است و توزیع با مشتری است

            if (basket.Parcels.Any(x => x.NeedsDistribution == false))
            {
                response.DistributionPrice = 0;
                response.CommentDistribution =
                    "چون اولین سفارش نیاز به توزیه ندارد،این سفارش یا سفارشات به درخواست مشتری نیاز به توزیع ندارد";
            }

            return response;
        }

    }
}
