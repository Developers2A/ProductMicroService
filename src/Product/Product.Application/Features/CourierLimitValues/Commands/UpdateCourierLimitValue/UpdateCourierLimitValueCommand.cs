using Product.Application.Contracts;

namespace Product.Application.Features.CourierLimitValues.Commands.UpdateCourierLimitValue
{
    public class UpdateCourierLimitValueCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public float LowerLimit { get; set; }
        public float UpperLimit { get; set; }
    }
}
