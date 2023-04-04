using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByUser
{
    public class GetByUserContractValueAddedQuery : IRequest<List<ContractValueAddedDto>>
    {
        public Guid? UserId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
