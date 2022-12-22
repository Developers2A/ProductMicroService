using Product.Domain.Enums;

namespace Product.Application.Dtos.CollectionDistributions
{
    public class CourierCityTypePriceDto
    {
        public int Id { get; set; }
        public string CourierName { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public CityTypeCode CityType { get; set; }
        public double Volume { get; set; }
    }
}
