using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierLimits.Commands.CreateCourierLimit
{
    public class CreateCourierLimitCommand : ITransactionRequest
    {
        public string Name { get; set; }
    }
}
