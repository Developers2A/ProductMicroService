using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.Couriers.Commands.CreateCourier
{
    public class CreateCourierCommand : ITransactionRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
