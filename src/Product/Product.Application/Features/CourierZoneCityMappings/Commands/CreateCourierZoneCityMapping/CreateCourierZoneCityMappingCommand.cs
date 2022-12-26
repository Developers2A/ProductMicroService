using Product.Application.Contracts;

namespace Product.Application.Features.CourierZoneCityMappings.Commands.CreateCourierZoneCityMapping
{
    public class CreateCourierZoneCityMappingCommand : ITransactionRequest
    {
        public int CourierZoneId { get; set; }
        public int CityId { get; set; }
    }
}
