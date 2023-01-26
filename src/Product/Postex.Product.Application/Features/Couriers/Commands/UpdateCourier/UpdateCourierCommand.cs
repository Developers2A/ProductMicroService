using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.Couriers.Commands.UpdateCourier
{
    public class UpdateCourierCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Days { get; set; }
    }
}
