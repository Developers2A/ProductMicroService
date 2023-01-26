namespace Product.Application.Dtos.CollectionDistributionPrices.Basket
{
    public class PriceResponseDto
    {
        public List<BoxPrice> BoxSizes { get; set; }
        public decimal? CollectionPrice { get; set; }
        public decimal? DistributionPrice { get; set; }
        public string CommentCollection { get; set; }
        public string CommentDistribution { get; set; }
        public decimal WalletCollection { get; set; }
        public decimal WalletDistribution { get; set; }
        public string BasketId { get; set; }
        public string ErrorResponse { get; set; }
        public override string ToString()
        {
            return $"collection={CollectionPrice} distribution={DistributionPrice}";
        }

        public PriceResponseDto()
        {
            BoxSizes = new List<BoxPrice>();
        }
    }
}