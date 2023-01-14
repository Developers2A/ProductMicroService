using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Domain;

namespace Product.Domain.ValueAddedPrices
{
    public class ValueAddedPrice : BaseEntity<int>
    {
        public string Name { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public ValueAddedType ValueAddedType { get; set; }
    }
}
