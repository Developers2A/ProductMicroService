using Product.Application.Contracts;

namespace Product.Application.Features.CourierServices.Commands.CreateCourierService
{
    public class CreateCourierServiceCommand : ITransactionRequest
    {
        public int CourierId { get; set; }
        public string Name { get; set; }
        public string Days { get; set; }
    }
}
