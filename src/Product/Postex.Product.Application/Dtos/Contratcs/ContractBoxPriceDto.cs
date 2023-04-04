using Postex.Product.Domain.Contracts;

namespace Postex.Product.Application.Dtos.Contratcs
{
    public class ContractBoxPriceDto
    {
        public int Id { get; set; }
        public int BoxTypeId { get; set; }
        public string BoxName { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public int ContractInfoId { get; set; }
        public ContractInfo ContractInfo { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public Guid? UserId { get; set; }
        public decimal SalePrice { get; set; }
        public decimal BuyPrice { get; set; }
        public string Description { get; set; }
        public string LevelPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
