using Product.Application.Contracts;

namespace Product.Application.Features.CourierStatusMappings.Commands.CreateCourierStatusMapping
{
    public class CreateCourierStatusMappingCommand : ITransactionRequest
    {
        public int CourierApiId { get; set; }
        public int StatusId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
