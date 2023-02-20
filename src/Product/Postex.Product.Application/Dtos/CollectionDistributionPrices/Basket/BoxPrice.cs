using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket
{
    public class BoxPrice
    {
        public string? SizeOfBox { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public decimal? CollectionPrice { get; set; } = 0;
        public decimal? DistributionPrice { get; set; } = 0;
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public CityTypeCode DestinationCityTypeCode { get; set; }
        public bool IsNew { get; set; }
        public bool IsCanceled { get; set; }
        public bool HasCollection { get; set; }
        public bool HasDistribution { get; set; }
    }
}
