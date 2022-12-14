using Product.Application.Contracts;

namespace Product.Application.Features.CourierServiceZonePrices.Commands.UpdateCourierServiceZonePrice
{
    public class UpdateCourierServiceZonePriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public int StateId { get; set; }
        public int CityDestinationId { get; set; }
        public int CityOrigionId { get; set; }
        public int ZoneId { get; set; }
        public string? SLA { get; set; }
    }
}
