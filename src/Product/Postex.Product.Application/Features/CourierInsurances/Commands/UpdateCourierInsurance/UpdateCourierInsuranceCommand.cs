using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierInsurances.Commands.UpdateCourierInsurance
{
    public class UpdateCourierInsuranceCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
