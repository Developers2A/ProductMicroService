using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Contracts;

public class ContractInsurance : BaseEntity<int>
{
    public ContractInfo ContractInfo { get; set; }
    public int ContractInfoId { get; set; }
    public int? ProvinceId { get; set; }
    public int? CityId { get; set; }
    public int FromValue { get; set; }
    public int ToValue { get; set; }
    public double FixedPercent { get; set; }
    public int FixedValue { get; set; }
    public string Description { get; set; }

    public bool IsActice { get; set; }


}
