using Product.Application.Contracts;

namespace Product.Application.Features.CourierCityMappings.Commands.CreateCourierCityMapping
{
    public class CreateCourierCityMappingCommand : ITransactionRequest
    {
        public int CourierId { get; set; }
        public int CityId { get; set; }
        public int Code { get; set; }
        public string MappedCode { get; set; }
    }
}
