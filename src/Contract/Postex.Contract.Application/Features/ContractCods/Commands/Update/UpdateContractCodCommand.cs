using Postex.Contract.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractCods.Commands.Update
{
    public class UpdateContractCodCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public int FromValue { get; set; }
        public int ToValue { get; set; }
        public double FixedPercent { get; set; }
        public int FixedValue { get; set; }
        public string Description { get; set; }
        public bool IsActice { get; set; }
    }
}
