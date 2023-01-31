using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierZoneCityMappings.Commands.UpdateCourierZoneCityMapping
{
    public class UpdateCourierZoneCityMappingCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public int CourierZoneId { get; set; }
        public int CityId { get; set; }
    }
}
