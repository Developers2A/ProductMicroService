using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractInfos.Queries.GetContractById
{
    public class GetContractByIdQuery : IRequest<ContractInfoDto>
    {
        public int Id { get; set; }
    }
}
