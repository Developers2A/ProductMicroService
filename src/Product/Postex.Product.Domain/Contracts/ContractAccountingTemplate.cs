using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Contracts
{
    public class ContractAccountingTemplate : BaseEntity<int>
    {
        public int ContractInfoId { get; set; }
        public ContractInfo ContractInfo { get; set; }
        public string ContractDetailType { get; set; }
        public int ContractDetailId { get; set; }
        public int CustomerId { get; set; }
        public double PercentValue { get; set; }
        public int FixedValue { get; set; }
        public string Description { get; set; }
    }
}
