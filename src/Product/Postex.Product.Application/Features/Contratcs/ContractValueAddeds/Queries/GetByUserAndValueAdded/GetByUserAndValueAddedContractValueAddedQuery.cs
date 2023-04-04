using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByUserAndValueAdded
{
    public class GetByUserAndValueAddedContractValueAddedQuery : IRequest<ValueAddedPriceDto>
    {
        public int ValueAddedId { get; set; }
        public Guid? UserId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
