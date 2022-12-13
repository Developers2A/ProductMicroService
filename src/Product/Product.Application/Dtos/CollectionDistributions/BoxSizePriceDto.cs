using Product.Domain.Enums;

namespace Product.Application.Dtos.CollectionDistributions
{
    public class BoxSizePriceDto
    {
        public string SizeOfBox { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public decimal CollectionPrice { get; set; }
        public decimal DistributionPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public CityType DestinationCityTypeId { get; set; }
        public string ShipmentId { get; set; }
        public bool IsNew { get; set; }
        public bool IsCanceled { get; set; }
        public bool NeedsCollection { get; set; }
        public bool NeedsDistribution { get; set; }
    }
}