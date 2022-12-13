using Product.Application.Contracts;

namespace Product.Application.Features.CourierZoneSLAPrices.Commands.CreateCourierZoneSLAPrice
{
    public class CreateCourierZoneSLAPriceCommand : ITransactionRequest
    {
        public int CourierZoneSlAId { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int VolumeId { get; set; }
        public int WeightId { get; set; }
    }
}
