using Product.Application.Contracts;

namespace Product.Application.Features.CourierServiceZones.Commands.CreateCourierServiceZone
{
    public class CreateCourierServiceZoneCommand : ITransactionRequest
    {
        public int CourierId { get; set; }
        public int StateFromId { get; set; }
        public int StateToId { get; set; }
        public int? CityFromId { get; set; }
        public int? CityToId { get; set; }
        public int? ZoneId { get; set; }
        public int CourierServiceId { get; set; }
    }
}
