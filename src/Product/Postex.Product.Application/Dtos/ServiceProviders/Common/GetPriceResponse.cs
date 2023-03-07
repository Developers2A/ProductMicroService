namespace Postex.Product.Application.Dtos.ServiceProviders.Common
{
    public class GetPriceResponse
    {
        public ContractPriceDto BoxPrice { get; set; }
        public ContractInsurancePriceDto InsurancePrice { get; set; }
        public List<ServicePriceDto> ServicePrices { get; set; }
        public List<CollectionDistributionPriceDto> CollectionPrices { get; set; }
        public List<CollectionDistributionPriceDto> DistributionPrices { get; set; }
        public List<ContractValueAddedPriceDto> ValueAddedPrices { get; set; }

        public int TasviePrice { get; set; }
    }

    public class ServicePriceDto
    {
        public string CourierName { get; set; }
        public int CourierCode { get; set; }
        public long CourierTax { get; set; }
        public long DiscountAmount { get; set; }
        public long InsurancePrice { get; set; }
        public long PostexPrice { get; set; }
        public long PostexTax { get; set; }
        public long TotalPrice { get; set; }
        public ContractInsurancePriceDto ContractInsurancePrice { get; set; }
    }

    public class CollectionDistributionPriceDto
    {
        public string CourierName { get; set; }
        public int CourierCode { get; set; }
        public long Price { get; set; }
    }
}
