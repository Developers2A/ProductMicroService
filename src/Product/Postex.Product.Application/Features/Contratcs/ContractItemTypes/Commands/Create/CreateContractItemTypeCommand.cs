using Postex.Product.Application.Contracts;
using Postex.Product.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractItemTypes.Commands.CreateContractItemType
{
    public class CreateContractItemTypeCommand:ITransactionRequest<ContractItemType>
    {
        public string ContractTypeCode { get; set; }
        public string ContractTypeName { get; set; }
    }
}
