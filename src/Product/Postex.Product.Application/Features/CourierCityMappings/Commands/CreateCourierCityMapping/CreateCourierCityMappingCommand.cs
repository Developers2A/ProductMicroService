using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierCityMappings.Commands.CreateCourierCityMapping
{
    public class CreateCourierCityMappingCommand : ITransactionRequest
    {
        public int CourierId { get; set; }
        public int CityId { get; set; }
        public int Code { get; set; }
        public string MappedCode { get; set; }
    }
}
