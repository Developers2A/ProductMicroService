using Product.Application.Contracts;

namespace Product.Application.Features.CourierServiceZonePrices.Commands.CreateCourierServiceZonePrice
{
    public class CreateCourierServiceZonePricePriceCommand : ITransactionRequest
    {
        public int CourierServiceZoneId { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int VolumeId { get; set; }
        public int WeightId { get; set; }
    }
}
