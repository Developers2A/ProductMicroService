using Product.Application.Contracts;

namespace Product.Application.Features.CourierInsurances.Commands.CreateCourierInsurance
{
    public class CreateCourierInsuranceCommand : ITransactionRequest
    {
        public string Name { get; set; }
    }
}
