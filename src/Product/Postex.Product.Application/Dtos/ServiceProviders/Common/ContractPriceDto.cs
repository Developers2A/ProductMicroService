namespace Postex.Product.Application.Dtos.ServiceProviders.Common
{
    public class ContractPriceDto
    {
        public int ContractId { get; set; }
        public int ContractItemId { get; set; }
        public decimal DefaultSalePrice { get; set; }
        public decimal DefaultBuyPrice { get; set; }
        public decimal ContractSalePrice { get; set; }
        public decimal ContractBuyPrice { get; set; }
    }
}
