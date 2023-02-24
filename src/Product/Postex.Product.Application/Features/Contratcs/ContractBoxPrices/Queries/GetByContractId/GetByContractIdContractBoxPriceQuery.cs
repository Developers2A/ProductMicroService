using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByContractId
{
    public class GetByContractIdContractBoxPriceQuery : IRequest<List<ContractBoxPriceDto>>
    {
        public int ContractInfoId { get; set; }
    }
}
