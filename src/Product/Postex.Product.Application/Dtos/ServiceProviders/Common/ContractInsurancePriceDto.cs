namespace Postex.Product.Application.Dtos.ServiceProviders.Common
{
    public class ContractInsurancePriceDto
    {
        public int ContractId { get; set; }
        public int ContractInsuranceId { get; set; }
        public decimal DefaultPrice { get; set; }
        public decimal ContractPrice { get; set; }
    }
}
