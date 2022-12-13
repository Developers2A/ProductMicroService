using Product.Application.Contracts;

namespace Product.Application.Features.Weights.Commands.UpdateWeight
{
    public class UpdateWeightCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public int PostageWeight { get; set; }
        public string Code { get; set; }
    }
}
