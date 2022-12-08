using Product.Application.Contracts;

namespace Product.Application.Features.CourierStatusMappings.Commands.DeleteCourierStatusMapping
{
    public class DeleteCourierStatusMappingCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
