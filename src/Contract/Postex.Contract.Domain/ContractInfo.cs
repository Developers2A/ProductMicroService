using Postex.SharedKernel.Domain;

namespace Postex.Contract.Domain;

public class ContractInfo : BaseEntity<int>
{
    public string ContractNo { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime RegisterDate { get; set; }
    public Customer? Customer { get; set; }
    public int? CustomerId { get; set; }
    public bool IsActive { get; set; }    
    public ICollection<ContractInsurance> ContractInsurances { get; set; }
    public ICollection<ContractBoxType> ContractBoxTypes { get; set; }
    public ICollection<ContractCollect_Distribute> ContractCollect_Distributes { get; set; }
    public ICollection<ContractCod> ContractCods { get; set; }
}

