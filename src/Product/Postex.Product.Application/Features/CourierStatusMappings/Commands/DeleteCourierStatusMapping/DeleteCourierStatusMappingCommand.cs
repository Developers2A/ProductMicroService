using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierStatusMappings.Commands.DeleteCourierStatusMapping
{
    public class DeleteCourierStatusMappingCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
