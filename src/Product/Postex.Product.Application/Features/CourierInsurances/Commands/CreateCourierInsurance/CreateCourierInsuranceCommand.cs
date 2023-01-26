using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierInsurances.Commands.CreateCourierInsurance
{
    public class CreateCourierInsuranceCommand : ITransactionRequest
    {
        public string Name { get; set; }
    }
}
