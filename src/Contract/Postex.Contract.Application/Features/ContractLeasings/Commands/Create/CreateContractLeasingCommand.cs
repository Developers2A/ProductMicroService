using Postex.Contract.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractLeasings.Command.Create
{
    public class CreateContractLeasingCommand : ITransactionRequest
    {

        public int CustomerId { get; set; }

        public int Amount { get; set; }

        public double ReturnRate { get; set; }

        public double WithdrawRate { get; set; }

        public int DailyDepositRateCeiling { get; set; }

        public double DailyDepositeRate { get; set; }

        public bool IsActive { get; set; }
    }
}
