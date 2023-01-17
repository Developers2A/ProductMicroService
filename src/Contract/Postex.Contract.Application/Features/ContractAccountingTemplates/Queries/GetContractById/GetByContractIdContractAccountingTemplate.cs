using MediatR;
using Postex.Contract.Application.Dtos;
using Postex.Contract.Domain;

namespace Postex.Contract.Application.Features.ContractAccountingTemplates.Queries.GetContractById
{
    public class GetByContractIdContractAccountingTemplate:IRequest<ContractAccountingTemplate>
    {
        public int ContractInfoId { get; set; }
    }
}
