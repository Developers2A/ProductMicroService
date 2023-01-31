using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.PostexInsurances.Commands.UpdatePostexInsurance
{
    public class UpdatePostexInsuranceCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
