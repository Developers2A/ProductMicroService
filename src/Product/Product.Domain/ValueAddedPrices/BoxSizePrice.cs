using Postex.SharedKernel.Domain;

namespace Product.Domain.ValueAddedPrices
{
    public class BoxSizePrice : BaseEntity<int>
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
    }
}
