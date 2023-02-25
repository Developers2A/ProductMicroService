using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.ValueAddedPrices
{
    public class ValueAddedPrice : BaseEntity<int>
    {
        public int ValueAddedTypeId { get; set; }
        public ValueAddedType ValueAddedType { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
