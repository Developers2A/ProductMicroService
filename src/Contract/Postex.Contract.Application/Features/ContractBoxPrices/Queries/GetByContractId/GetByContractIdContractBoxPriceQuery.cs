using MediatR;
using Postex.Contract.Application.Dtos;

namespace Postex.Contract.Application.Features.ContractBoxPrices.Queries.GetByContractId
{
    public class GetByContractIdContractBoxPriceQuery : IRequest<List<ContractBoxPriceDto>>
    {
        public int ContractInfoId { get; set; }
    }
}
