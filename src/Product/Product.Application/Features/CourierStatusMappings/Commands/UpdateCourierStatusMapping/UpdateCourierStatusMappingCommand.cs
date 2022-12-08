using Product.Application.Contracts;

namespace Product.Application.Features.CourierStatusMappings.Commands.UpdateCourierStatusMapping
{
    public class UpdateCourierStatusMappingCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public int StatusId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
