namespace Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket
{
    public class PudoPriceResponseDto
    {
        public string City { get; set; }
        public string Zone { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? BuyPrice { get; set; }
    }
}