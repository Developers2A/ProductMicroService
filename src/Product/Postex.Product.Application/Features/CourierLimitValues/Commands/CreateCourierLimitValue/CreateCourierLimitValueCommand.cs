using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierLimitValues.Commands.CreateCourierLimitValue
{
    public class CreateCourierLimitValueCommand : ITransactionRequest
    {
        public int CourierId { get; set; }
        public int CourierLimitId { get; set; }
        public int? CityId { get; set; }
        public int FromOrToType { get; set; }
        public float LowerLimit { get; set; }
        public float UpperLimit { get; set; }
    }
}
