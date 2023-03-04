using MediatR;
using Postex.Contract.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.Contratcs.ContractAccountingTemplates.Queries.GetByContractAndDetailId
{
    public class GetByContractAndDetailIdContractAccountingTemplate:IRequest<List<ContractAccountingTemplate>>
    {
        public int ContractInfoId { get; set; }
        public int ContractDeatilId { get; set; }
        public string ContractDetailType { get; set; }
    }
}
