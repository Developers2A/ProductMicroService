using MediatR;
using Postex.Product.Application.Dtos;

namespace Postex.Product.Application.Features.ContractItemTypes.Queries
{
    public class GetContractItemTypeQuery : IRequest<List<ContractItemTypeDto>>
    {
       
    }  
}
