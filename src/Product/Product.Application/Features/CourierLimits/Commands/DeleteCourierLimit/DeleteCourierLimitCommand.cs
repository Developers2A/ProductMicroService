using Product.Application.Contracts;

namespace Product.Application.Features.CourierLimits.Commands.DeleteCourierLimit
{
    public class DeleteCourierLimitCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
