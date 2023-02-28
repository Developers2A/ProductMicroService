namespace Postex.Product.Application.Dtos.ServiceProviders.Common
{
    public class PriceDto
    {
        public decimal DefaultSalePrice { get; set; }
        public decimal DefaultBuyPrice { get; set; }
        public decimal ContractSalePrice { get; set; }
        public decimal ContractBuyPrice { get; set; }
    }
}
