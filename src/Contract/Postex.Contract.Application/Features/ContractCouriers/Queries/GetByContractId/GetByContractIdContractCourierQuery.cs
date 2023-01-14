using MediatR;
using Postex.Contract.Application.Dtos;

namespace Postex.Contract.Application.Features.ContractCouriers.Queries
{
    public class GetByContractIdContractCourierQuery : IRequest<List<ContractCourierDto>>
    {
        public int ContractInfoId { get; set; }
    }
}
