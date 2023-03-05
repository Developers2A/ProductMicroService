using MediatR;
using Postex.Product.Domain.Contracts;

namespace Postex.Product.Application.Features.Contratcs.ContractAccountingTemplates.Queries.GetByContractAndDetailId
{
    public class GetByContractAndDetailIdContractAccountingTemplate : IRequest<List<ContractAccountingTemplate>>
    {
        public int ContractInfoId { get; set; }
        public int ContractDeatilId { get; set; }
        public string ContractDetailType { get; set; }
    }
}
