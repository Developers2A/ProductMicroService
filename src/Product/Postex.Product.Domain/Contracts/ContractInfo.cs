using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Contracts;

public class ContractInfo : BaseEntity<int>
{
    public string ContractNo { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime RegisterDate { get; set; }
    public Guid? UserId { get; set; }
    public int? CityId { get; set; }
    public int? ProvinceId { get; set; }
    public bool IsActive { get; set; }
    public ICollection<ContractInsurance> ContractInsurances { get; set; }
    public ICollection<ContractBoxPrice> ContractBoxPrices { get; set; }
    public ICollection<ContractCollectionDistribution> ContractCollectionDistributions { get; set; }
    public ICollection<ContractCod> ContractCods { get; set; }
}

