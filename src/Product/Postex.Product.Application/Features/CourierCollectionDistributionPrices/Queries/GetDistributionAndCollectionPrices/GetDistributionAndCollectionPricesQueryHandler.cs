using MediatR;
using Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket;
using Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetCollectionPrices;
using Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetDistributionPrices;

namespace Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetDistributionAndCollectionPrices
{
    public class GetDistributionAndCollectionPricesQueryHandler : IRequestHandler<GetDistributionAndCollectionPricesQuery, PriceResponseDto>
    {
        private readonly IMediator _mediator;
        private GetDistributionAndCollectionPricesQuery _query;

        public GetDistributionAndCollectionPricesQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<PriceResponseDto> Handle(GetDistributionAndCollectionPricesQuery query, CancellationToken cancellationToken)
        {
            _query = query;
            return await CalculateDistributionAndCollectionPrice();
        }

        private async Task<PriceResponseDto> CalculateDistributionAndCollectionPrice()
        {
            var collectionPrice = await _mediator.Send(new GetCollectionPricesQuery()
            {
                Basket = _query.Basket,
                CollectionDistributionPrices = _query.CollectionDistributionPrices
            });

            var distributionPrice = await _mediator.Send(new GetDistributionPricesQuery()
            {
                Basket = _query.Basket,
                CollectionDistributionPrices = _query.CollectionDistributionPrices
            });

            return new PriceResponseDto()
            {
                BasketId = _query.Basket.BasketId!,
                BoxSizes = distributionPrice.BoxSizes.Union(collectionPrice.BoxSizes).ToList(),
                CollectionPrice = collectionPrice.CollectionPrice,
                DistributionPrice = distributionPrice.DistributionPrice,
                CommentCollection = collectionPrice.CommentCollection,
                CommentDistribution = distributionPrice.CommentDistribution,
                ErrorResponse = collectionPrice.ErrorResponse + " " + distributionPrice.ErrorResponse,
                WalletCollection = collectionPrice.WalletCollection,
                WalletDistribution = distributionPrice.WalletDistribution
            };
        }
    }
}
