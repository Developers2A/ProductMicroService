using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.ContractValueAddeds.Queries
{
    public class GetByCustomerAndValueAddedContractValueAddedQuery : IRequest<ValueAddedPriceDto>
    {
        public int ValueAddedId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
