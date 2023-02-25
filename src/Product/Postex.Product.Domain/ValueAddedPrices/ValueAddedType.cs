using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.ValueAddedPrices
{
    public class ValueAddedType : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<ValueAddedPrice> ValueAddedPrices { get; set; }
        public ICollection<ContractValueAdded> ContractValueAddeds { get; set; }
    }
}
