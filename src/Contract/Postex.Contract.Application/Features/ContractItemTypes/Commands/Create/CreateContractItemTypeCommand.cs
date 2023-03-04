using Postex.Contract.Application.Contracts;
using Postex.Contract.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractItemTypes.Commands.Create
{
    public class CreateContractItemTypeCommand : ITransactionRequest<ContractItemType>
    {
        public string ContractTypeCode { get; set; }
        public string ContractTypeName { get; set; }
    }
}
