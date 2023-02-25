namespace Postex.Product.Application.Dtos.Couriers
{
    public class BoxPriceDto
    {
        public int Id { get; set; }
        public int BoxTypeId { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
    }
}
