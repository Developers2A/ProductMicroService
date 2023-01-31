using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.Couriers.Commands.DeleteCourier
{
    public class DeleteCourierCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
