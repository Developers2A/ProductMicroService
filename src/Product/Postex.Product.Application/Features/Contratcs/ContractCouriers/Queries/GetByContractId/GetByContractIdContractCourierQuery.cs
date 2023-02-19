using MediatR;
using Postex.Product.Application.Dtos;

namespace Postex.Product.Application.Features.ContractCouriers.Queries
{
    public class GetByContractIdContractCourierQuery : IRequest<List<ContractCourierDto>>
    {
        public int ContractInfoId { get; set; }
    }
}
