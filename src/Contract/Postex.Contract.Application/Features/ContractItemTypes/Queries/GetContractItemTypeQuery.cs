using MediatR;
using Postex.Contract.Application.Dtos;

namespace Postex.Contract.Application.Features.ContractItemTypes.Queries
{
    public class GetContractItemTypeQuery : IRequest<List<ContractItemTypeDto>>
    {
       
    }  
}
