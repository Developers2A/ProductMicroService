using Product.Application.Contracts;

namespace Product.Application.Features.CourierServiceZones.Commands.UpdateCourierServiceZone
{
    public class UpdateCourierServiceZoneCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public int StateId { get; set; }
        public int CityFromId { get; set; }
        public int CityToId { get; set; }
        public int ZoneId { get; set; }
        public int CourierServiceId { get; set; }
    }
}
