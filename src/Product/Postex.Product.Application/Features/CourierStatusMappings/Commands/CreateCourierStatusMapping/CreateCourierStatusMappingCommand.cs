using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierStatusMappings.Commands.CreateCourierStatusMapping
{
    public class CreateCourierStatusMappingCommand : ITransactionRequest
    {
        public int CourierId { get; set; }
        public int Version { get; set; }
        public int StatusId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
