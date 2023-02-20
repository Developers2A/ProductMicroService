using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.ValueAddedPrices
{
    public class BoxSizePrice : BaseEntity<int>
    {
        public int BoxTypeId { get; set; }
        public BoxType BoxType { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
    }
}
