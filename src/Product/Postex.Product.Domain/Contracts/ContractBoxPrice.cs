using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain
{

    public class ContractBoxPrice : BaseEntity<int>
    {
        public int BoxTypeId { get; set; }
        public BoxType BoxType { get; set; }
        public int ContractInfoId { get; set; }
        public ContractInfo ContractInfo { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public Guid? CustomerId { get; set; }        
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}