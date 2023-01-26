using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierZoneCityMappings.Commands.CreateCourierZoneCityMapping
{
    public class CreateCourierZoneCityMappingCommand : ITransactionRequest
    {
        public int CourierZoneId { get; set; }
        public int CityId { get; set; }
    }
}
