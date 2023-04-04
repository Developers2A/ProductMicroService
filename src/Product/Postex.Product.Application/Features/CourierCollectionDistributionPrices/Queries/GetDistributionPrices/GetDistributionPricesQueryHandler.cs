using MediatR;
using Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket;
using Postex.Product.Application.Dtos.CollectionDistributionPrices.Helper;

namespace Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetDistributionPrices
{
    public class GetDistributionPricesQueryHandler : IRequestHandler<GetDistributionPricesQuery, PriceResponseDto>
    {
        private readonly IMediator _mediator;
        private GetDistributionPricesQuery _query;

        public GetDistributionPricesQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<PriceResponseDto> Handle(GetDistributionPricesQuery query, CancellationToken cancellationToken)
        {
            _query = query;
            return Task.FromResult(CalculateDistribution(_query.Basket));
        }

        private PriceResponseDto CalculateDistribution(BasketDto basket)
        {
            var priceResponse = new PriceResponseDto
            {
                BasketId = basket.BasketId
            };

            foreach (var parcel in basket.Parcels)
            {
                BoxSizeDto? byVolume = GetPriceByVolume(parcel);
                if (byVolume != null)
                {
                    if (parcel.DistributionPrice > byVolume.SellPrice)
                    {
                        priceResponse.ErrorResponse = "قیمت توزیع بسته ارسالی از قیمت فروش آن بیشتراست. سبد را بازبینی کنید ";
                        priceResponse.CollectionPrice = null;
                        priceResponse.DistributionPrice = null;
                        return priceResponse;
                    }

                    if (parcel.IsNew && !parcel.IsCanceled)
                    {
                        parcel.DistributionPrice = byVolume.SellPrice;
                        parcel.BuyPrice = byVolume.BuyPrice;
                        parcel.SellPrice = byVolume.SellPrice;
                        //اگر بسته  یا هر کدام از بسته های یک درخواست در سبد ارسالی نیاز به توزیع نداشت ، هزینه  توزیع سبد صفر است و توزیع با مشتری است
                    }
                    if (parcel.HasDistribution == false)
                    {
                        parcel.DistributionPrice = 0;
                    }
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

        private BoxSizeDto? GetPriceByVolume(BoxPrice parcel)
        {
            var price = _query.CollectionDistributionPrices.Where(x =>
                x.CityType == parcel.DestinationCityTypeCode &&
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
    }
}
