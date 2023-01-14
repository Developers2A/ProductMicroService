using MediatR;
using Postex.Contract.Application.Contracts;
using Postex.Contract.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractCollect_Distributes.Queries
{
    public class GetByContractIdContractCollect_DistributeQuery : IRequest<List<ContractCollect_DistributeDto>>
    {
        public int ContractInfoId { get; set; }
    }
}
