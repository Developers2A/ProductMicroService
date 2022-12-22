using Product.Application.Contracts;

namespace Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrice
{
    public class CreateCourierZonePriceCommand : ITransactionRequest
    {
        public int FromCourierZoneId { get; set; }
        public int ToCourierZoneId { get; set; }
        public int CourierServiceId { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int Weight { get; set; }
    }
}
