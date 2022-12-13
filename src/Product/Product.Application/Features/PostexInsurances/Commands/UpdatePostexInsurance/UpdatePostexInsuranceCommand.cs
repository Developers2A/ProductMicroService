using Product.Application.Contracts;

namespace Product.Application.Features.PostexInsurances.Commands.UpdatePostexInsurance
{
    public class UpdatePostexInsuranceCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
