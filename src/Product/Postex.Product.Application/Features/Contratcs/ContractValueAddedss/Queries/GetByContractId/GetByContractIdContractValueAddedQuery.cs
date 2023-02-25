using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractItems.Queries.GetByContractId
{
    public class GetByContractIdContractValueAddedQuery : IRequest<List<ContractItemDto>>
    {
        public int ContractInfoId { get; set; }
    }
}
