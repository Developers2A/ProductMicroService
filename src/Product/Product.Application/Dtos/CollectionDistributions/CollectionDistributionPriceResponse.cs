#nullable enable
using Product.Application.Dtos.CollectionDistributions;

namespace ParcelPriceCalculatorPaykhub.Models.ViewModels
{
    public class CollectionDistributionPriceResponse
    {
        public List<ParcelPrice> BoxSizes { get; set; }
        public decimal? CollectionPrice { get; set; }
        public decimal? DistributionPrice { get; set; }
        public string CommentCollection { get; set; }
        public string CommentDistribution { get; set; }
        public decimal WalletCollection { get; set; }
        public decimal WalletDistribution { get; set; }
        public string BasketId { get; set; }
        public string? ErrorResponse { get; set; }
        public override string ToString()
        {
            return $"collection={CollectionPrice} distribution={DistributionPrice}";
        }

        public CollectionDistributionPriceResponse()
        {
            BoxSizes = new List<ParcelPrice>();
        }
    }
}