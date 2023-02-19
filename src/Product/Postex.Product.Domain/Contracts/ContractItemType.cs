using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain
{

    public class ContractItemType : BaseEntity<int>
    {
        public string ContractTypeCode { get; set; }
        public string ContractTypeName { get; set; }
    }
}
