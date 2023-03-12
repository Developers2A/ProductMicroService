using Postex.Product.Domain.Common;
using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Contracts;

public class ContractValueAdded : BaseEntity<int>
{
    public ContractInfo ContractInfo { get; set; }
    public int ContractInfoId { get; set; }
    public int CourierId { get; set; }
    public int ValueAddedTypeId { get; set; }
    public ValueAddedType ValueAddedType { get; set; }
    public int? ProvinceId { get; set; }
    public int? CityId { get; set; }
    public bool IsActive { get; set; }
    public decimal SalePrice { get; set; }
    public decimal BuyPrice { get; set; }
    public string? Description { get; set; }
}