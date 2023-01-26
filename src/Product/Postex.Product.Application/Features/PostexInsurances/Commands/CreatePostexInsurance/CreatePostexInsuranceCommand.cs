using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.PostexInsurances.Commands.CreatePostexInsurance
{
    public class CreatePostexInsuranceCommand : ITransactionRequest
    {
        public string Name { get; set; }
    }
}
