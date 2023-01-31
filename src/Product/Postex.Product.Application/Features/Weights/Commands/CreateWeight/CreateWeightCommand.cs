using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.Weights.Commands.CreateWeight
{
    public class CreateWeightCommand : ITransactionRequest
    {
        public int PostageWeight { get; set; }
        public string Code { get; set; }
    }
}
