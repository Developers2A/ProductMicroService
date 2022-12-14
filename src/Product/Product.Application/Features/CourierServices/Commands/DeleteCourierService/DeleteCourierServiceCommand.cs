using Product.Application.Contracts;

namespace Product.Application.Features.CourierServices.Commands.DeleteCourierService
{
    public class DeleteCourierServiceCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
