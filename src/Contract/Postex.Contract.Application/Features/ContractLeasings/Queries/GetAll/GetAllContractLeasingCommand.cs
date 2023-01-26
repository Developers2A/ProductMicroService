using Postex.Contract.Application.Contracts;
using Postex.Contract.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractLeasings.Queries.GetAll
{
    public class GetAllContractLeasingCommand : ITransactionRequest<List<ContractLeasingDto>>
    {

    }
}
