using Product.Domain.Enums;

namespace Product.Application.Dtos.CollectionDistributions
{
    public class ParcelCityDto
    {
        public int Id { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public CityType CityType { get; set; }
        public double Volume { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
