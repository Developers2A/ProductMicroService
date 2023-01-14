using Postex.SharedKernel.Domain;

namespace Postex.Contract.Domain
{

    public class ContractItem : BaseEntity<int>
    {
        public ContractInfo ContractInfo { get; set; }
        public int ContractInfoId { get; set; }
        public int CourierId { get; set; }
        public ContractItemType ContractItemType { get; set; }
        public int ContractItemTypeId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }      
        public Customer? Customer { get; set; }
        public bool IsActive { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public string Description { get; set; }

    }

}