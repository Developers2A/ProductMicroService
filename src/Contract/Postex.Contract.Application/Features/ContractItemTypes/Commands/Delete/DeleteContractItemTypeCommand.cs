using Postex.Contract.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractItemTypes.Commands.Delete
{
    public class DeleteContractItemTypeCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
