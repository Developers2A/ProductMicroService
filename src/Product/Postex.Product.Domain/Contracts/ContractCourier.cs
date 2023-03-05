using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Contracts;

public class ContractCourier : BaseEntity<int>
{
    public ContractInfo ContractInfo { get; set; }
    public int ContractInfoId { get; set; }
    public int CourierServiceId { get; set; }
    public int FixedDiscount { get; set; }
    public double PercentDiscount { get; set; }
    public bool IsActive { get; set; }
    public string Description { get; set; }

}
