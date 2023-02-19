using Postex.Product.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractItemTypes.Commands.DeleteContratcItemType
{
    public class DeleteContractItemTypeCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
