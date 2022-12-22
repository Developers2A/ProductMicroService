using Product.Application.Contracts;

namespace Product.Application.Features.Couriers.Commands.UpdateCourier
{
    public class UpdateCourierCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Days { get; set; }
    }
}
