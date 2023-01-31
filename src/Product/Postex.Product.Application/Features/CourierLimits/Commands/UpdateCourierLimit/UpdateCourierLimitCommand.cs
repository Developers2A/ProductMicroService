using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierLimits.Commands.UpdateCourierLimit
{
    public class UpdateCourierLimitCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
