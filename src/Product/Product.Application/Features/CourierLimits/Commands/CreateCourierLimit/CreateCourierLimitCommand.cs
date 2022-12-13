using Product.Application.Contracts;

namespace Product.Application.Features.CourierLimits.Commands.CreateCourierLimit
{
    public class CreateCourierLimitCommand : ITransactionRequest
    {
        public string Name { get; set; }
    }
}
