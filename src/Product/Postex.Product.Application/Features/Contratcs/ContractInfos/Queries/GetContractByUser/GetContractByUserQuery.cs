using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractInfos.Queries.GetContractByUser
{
    public class GetContractByUserQuery : IRequest<ContractInfoDto>
    {
        public Guid UserId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
