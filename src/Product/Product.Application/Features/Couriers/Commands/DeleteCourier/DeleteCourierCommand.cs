using Product.Application.Contracts;

namespace Product.Application.Features.Couriers.Commands.DeleteCourier
{
    public class DeleteCourierCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
