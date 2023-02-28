namespace Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket
{
    public class BoxSizeDto
    {
        public int Id { get; set; }
        public string? SizeOfBox { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
