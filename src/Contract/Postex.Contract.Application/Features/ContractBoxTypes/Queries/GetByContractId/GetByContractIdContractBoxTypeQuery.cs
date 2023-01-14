using MediatR;
using Postex.Contract.Application.Dtos;

namespace Postex.Contract.Application.Features.ContractBoxTypes.Queries
{
    public class GetByContractIdContractBoxTypeQuery : IRequest<List<ContractBoxTypeDto>>
    {
        public int ContractInfoId { get; set; }
    }
}
