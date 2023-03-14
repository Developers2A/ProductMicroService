using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierZonePrices.Commands.UpdateCourierZonePrice
{
    public class UpdateCourierZonePriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public int FromCourierZoneId { get; set; }
        public int ToCourierZoneId { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int Weight { get; set; }
        public bool SameProvince { get; set; }
    }
}
