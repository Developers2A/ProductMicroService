using Product.Application.Contracts;

namespace Product.Application.Features.Weights.Commands.CreateWeight
{
    public class CreateWeightCommand : ITransactionRequest
    {
        public int PostageWeight { get; set; }
        public string Code { get; set; }
    }
}
