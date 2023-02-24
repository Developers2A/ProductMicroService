using MediatR;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Queries.GetByContractId
{
    public class GetByContractIdContractCollect_DistributeQuery : IRequest<List<ContractCollectionDistributionDto>>
    {
        public int ContractInfoId { get; set; }
    }
}
