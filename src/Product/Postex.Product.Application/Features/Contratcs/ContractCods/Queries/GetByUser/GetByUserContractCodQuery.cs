using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractCods.Queries.GetByUser
{
    public class GetByUserContractCodQuery : IRequest<List<ContractCodDto>>
    {
        public Guid? UserId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
