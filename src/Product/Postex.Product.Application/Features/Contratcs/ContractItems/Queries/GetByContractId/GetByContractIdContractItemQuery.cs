using MediatR;
using Postex.Product.Application.Dtos;

namespace Postex.Product.Application.Features.ContractItems.Queries
{
    public class GetByContractIdContractItemQuery:IRequest<List<ContractItemDto>>
    {
        public int ContractInfoId { get; set; }
    }
}
