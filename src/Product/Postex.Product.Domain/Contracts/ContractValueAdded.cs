using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Contracts
{

    public class ContractValueAdded : BaseEntity<int>
    {
        public ContractInfo ContractInfo { get; set; }
        public int ContractInfoId { get; set; }
        public int CourierId { get; set; }
        public int ContractItemTypeId { get; set; }
        public ValueAddedType ContractItemType { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public bool IsActive { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public string? Description { get; set; }

    }

}