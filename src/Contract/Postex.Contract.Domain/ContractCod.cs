using Postex.SharedKernel.Domain;

namespace Postex.Contract.Domain;

public class ContractCod : BaseEntity<int>
{
    public ContractInfo ContractInfo { get; set; }
    public int ContractInfoId { get; set; }
    public int CourierId { get; set; }
   
    public int FromValue { get; set; }
    public int ToValue { get; set; }
    public double FixedPercent { get; set; }
    public int FixedValue { get; set; }
    public string Description { get; set; }
}

