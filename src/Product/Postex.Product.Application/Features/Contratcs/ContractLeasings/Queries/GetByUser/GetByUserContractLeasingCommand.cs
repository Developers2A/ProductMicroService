using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractLeasings.Queries.GetByUser
{

    public class GetByUserContractLeasingCommand : IRequest<ContractLeasingDto>
    {
        public Guid UserId { get; set; }
    }
}
