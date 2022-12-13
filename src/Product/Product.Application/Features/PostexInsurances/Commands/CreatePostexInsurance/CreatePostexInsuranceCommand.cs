using Product.Application.Contracts;

namespace Product.Application.Features.PostexInsurances.Commands.CreatePostexInsurance
{
    public class CreatePostexInsuranceCommand : ITransactionRequest
    {
        public string Name { get; set; }
    }
}
