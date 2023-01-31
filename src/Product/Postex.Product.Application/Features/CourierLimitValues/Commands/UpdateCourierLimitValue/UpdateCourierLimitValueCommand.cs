using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierLimitValues.Commands.UpdateCourierLimitValue
{
    public class UpdateCourierLimitValueCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public float LowerLimit { get; set; }
        public float UpperLimit { get; set; }
    }
}
