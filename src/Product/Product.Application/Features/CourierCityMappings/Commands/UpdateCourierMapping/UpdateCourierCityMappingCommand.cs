using Product.Application.Contracts;

namespace Product.Application.Features.CourierCityMappings.Commands.UpdateCourierMapping
{
    public class UpdateCourierCityMappingCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public int CityId { get; set; }
        public int Code { get; set; }
        public string MappedCode { get; set; }
    }
}
