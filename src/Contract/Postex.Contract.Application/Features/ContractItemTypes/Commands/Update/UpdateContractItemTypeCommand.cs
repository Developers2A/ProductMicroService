using Postex.Contract.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractItemTypes.Commands.UpdateContractItemType
{
    public class UpdateContractItemTypeCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string ContractTypeCode { get; set; }
        public string ContractTypeName { get; set; }
    }
}
