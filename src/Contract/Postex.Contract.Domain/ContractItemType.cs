using Postex.SharedKernel.Domain;

namespace Postex.Contract.Domain
{

    public class ContractItemType : BaseEntity<int>
    {
        public string ContractTypeCode { get; set; }
        public string ContractTypeName { get; set; }
    }
}
