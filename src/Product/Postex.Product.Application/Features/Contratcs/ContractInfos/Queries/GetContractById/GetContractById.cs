using MediatR;
using Postex.Product.Application.Dtos;

namespace Postex.Product.Application.Features.Contracts.Queries.GetContractById
{
    public class GetContractById:IRequest<ContractInfoDto>
    {
        public int Id { get; set; }
    }
}
