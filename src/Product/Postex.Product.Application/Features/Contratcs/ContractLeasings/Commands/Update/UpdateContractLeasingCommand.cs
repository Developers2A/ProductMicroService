using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractLeasings.Commands.Update
{
    public class UpdateContractLeasingCommand : ITransactionRequest<ContractLeasingDto>
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Amount { get; set; }
        public double ReturnRate { get; set; }
        public double WithdrawRate { get; set; }
        public int DailyDepositRateCeiling { get; set; }
        public double DailyDepositeRate { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }

    }
}
