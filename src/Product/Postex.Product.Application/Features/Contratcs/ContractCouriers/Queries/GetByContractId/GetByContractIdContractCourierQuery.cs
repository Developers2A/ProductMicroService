using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByContractId
{
    public class GetByContractIdContractCourierQuery : IRequest<List<ContractCourierDto>>
    {
        public int ContractInfoId { get; set; }
    }
}
