namespace Postex.Product.Application.Dtos.Contratcs
{
    public class BoxPriceDto
    {
        public int BoxTypeId { get; set; }
        public int ContractId { get; set; }
        public int ContractBoxPriceId { get; set; }
        public decimal DefaultSalePrice { get; set; }
        public decimal DefaultBuyPrice { get; set; }
        public decimal ContractSalePrice { get; set; }
        public decimal ContractBuyPrice { get; set; }
        public string? ContractLevel { get; set; }
    }
}
