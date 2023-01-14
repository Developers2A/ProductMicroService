using Postex.Contract.Application.Contracts;

namespace Postex.Contract.Application.Features.ContractCouriers.Command.Create
{
    public class CreateContractCourierCommand : ITransactionRequest
    {
        public int ContractInfoId { get; set; }
        public int CourierId { get; set; }
        public int FixedDiscount { get; set; }
        public double PercentDiscount { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }

    }
}
