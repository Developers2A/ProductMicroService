namespace Postex.Product.Application.Dtos.Contratcs
{
    public class ValueAddedPriceDto
    {
        public int ValueAddedTypeId { get; set; }
        public string ValueAddedTypeName { get; set; }
        public int ContractId { get; set; }
        public int ContractValueAddedId { get; set; }
        public decimal DefaultSalePrice { get; set; }
        public decimal DefaultBuyPrice { get; set; }
        public decimal ContractSalePrice { get; set; }
        public decimal ContractBuyPrice { get; set; }
        public string ContractLevel { get; set; }

    }
}
