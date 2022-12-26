using Product.Application.Contracts;

namespace Product.Application.Features.CourierZoneCityMappings.Commands.UpdateCourierZoneCityMapping
{
    public class UpdateCourierZoneCityMappingCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public int CourierZoneId { get; set; }
        public int CityId { get; set; }
    }
}
