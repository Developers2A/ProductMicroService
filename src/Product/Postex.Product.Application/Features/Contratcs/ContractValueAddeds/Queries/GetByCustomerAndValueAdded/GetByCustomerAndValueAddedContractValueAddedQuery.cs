using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByCustomerAndValueAdded
{
    public class GetByCustomerAndValueAddedContractValueAddedQuery : IRequest<ValueAddedPriceDto>
    {
        public int ValueAddedId { get; set; }
        public int? CustomerId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
    }
}
