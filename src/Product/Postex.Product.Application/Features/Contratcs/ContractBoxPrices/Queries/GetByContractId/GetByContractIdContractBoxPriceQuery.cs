using MediatR;
using Postex.Product.Application.Dtos;

namespace Postex.Product.Application.Features.ContractBoxPrices.Queries
{
    public class GetByContractIdContractBoxPriceQuery : IRequest<List<ContractBoxPriceDto>>
    {
        public int ContractInfoId { get; set; }
    }
}
