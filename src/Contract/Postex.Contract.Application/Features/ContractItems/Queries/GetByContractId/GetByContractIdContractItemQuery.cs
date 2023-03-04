using MediatR;
using Postex.Contract.Application.Dtos;

namespace Postex.Contract.Application.Features.ContractItems.Queries.GetByContractId
{
    public class GetByContractIdContractItemQuery : IRequest<List<ContractItemDto>>
    {
        public int ContractInfoId { get; set; }
    }
}
