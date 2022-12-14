using Product.Application.Contracts;

namespace Product.Application.Features.CourierServices.Commands.UpdateCourierService
{
    public class UpdateCourierServiceCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Days { get; set; }
    }
}
