using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrice
{
    public class CreateCourierZonePriceCommand : ITransactionRequest
    {
        public int FromCourierZoneId { get; set; }
        public int ToCourierZoneId { get; set; }
        public int CourierServiceId { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int Weight { get; set; }
        public bool SameState { get; set; }
    }
}
