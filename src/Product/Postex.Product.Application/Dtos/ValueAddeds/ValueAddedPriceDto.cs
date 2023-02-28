namespace Postex.Product.Application.Dtos.ValueAddeds
{
    public class ValueAddedPriceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int ValueAddedTypeId { get; set; }
    }
}
