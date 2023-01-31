using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierLimits.Commands.DeleteCourierLimit
{
    public class DeleteCourierLimitCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
